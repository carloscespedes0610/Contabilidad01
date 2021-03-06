﻿using Contabilidad.Models.DAC;
using Contabilidad.Models.DAC.Carlos;
using Contabilidad.Models.VM;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;

namespace Contabilidad.Controllers
{
    [SessionExpireFilter]
    public class CenCosController : Controller
    {
        // GET: CenCos
        public ActionResult Index()
        {
            try
            {
                this.GetDefaultData();

                return View();
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: CenCos/Create
        public ActionResult Create()
        {
            clsCenCosVM oCenCosVM = new clsCenCosVM();

            try
            {
                this.GetDefaultData();

                oCenCosVM.EstadoId = ConstEstado.Activo;
                return View(oCenCosVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: CenCos/Create
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public ActionResult Create(clsCenCosVM oCenCosVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsCenCosCarlos oCenCos = new clsCenCosCarlos(clsAppInfo.Connection);
                    DataMove(oCenCosVM, oCenCos, false);

                    if (oCenCos.Insert())
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(oCenCosVM);
            }

            catch (Exception exp)
            {
                ViewBag.MessageErr = exp.Message;
                return View(oCenCosVM);
            }
        }

        // GET: CenCos/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsCenCosVM oCenCosVM = CenCosFind(SysData.ToLong(id));

                if (ReferenceEquals(oCenCosVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                return View(oCenCosVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: CenCos/Edit/5
        [HttpPost()]
        [ValidateAntiForgeryToken()]
        public ActionResult Edit(clsCenCosVM oCenCosVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsCenCosCarlos oCenCos = new clsCenCosCarlos(clsAppInfo.Connection);
                    DataMove(oCenCosVM, oCenCos, true);

                    if (oCenCos.Update())
                    {
                        return RedirectToAction("Index");
                    }
                }

                return View(oCenCosVM);
            }

            catch (Exception exp)
            {
                ViewBag.MessageErr = exp.Message;
                return View(oCenCosVM);
            }
        }

        // GET: CenCos/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsCenCosVM oCenCosVM = CenCosFind(SysData.ToLong(id));

                if (ReferenceEquals(oCenCosVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                return View(oCenCosVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: CenCos/Delete/5
        [HttpPost()]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken()]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsCenCos oCenCos = new clsCenCos(clsAppInfo.Connection);

                oCenCos.VM.CenCosId = SysData.ToLong(id);

                if (oCenCos.Delete())
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Error al Eliminar el Registro" });
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: CenCos/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                this.GetDefaultData();

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsCenCosVM oCenCosVM = CenCosFind(SysData.ToLong(id));

                if (ReferenceEquals(oCenCosVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice no encontrado" });
                }

                return View(oCenCosVM);
            }

            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        [HttpGet]
        public ActionResult CenCosGrid(DataSourceLoadOptions loadOptions)
        {
            return Content(JsonConvert.SerializeObject(CenCosGrid()), "application/json");
        }






        private void DataMove(clsCenCosVM oCenCosVM, clsCenCosCarlos oCenCos, bool boolEditing)
        {
            if (boolEditing)
            {
                oCenCos.VM.CenCosId = SysData.ToLong(oCenCosVM.CenCosId);
            }

            oCenCos.VM.CenCosCod = SysData.ToStr(oCenCosVM.CenCosCod);
            oCenCos.VM.CenCosDes = SysData.ToStr(oCenCosVM.CenCosDes);
            oCenCos.VM.CenCosEsp = SysData.ToStr(oCenCosVM.CenCosEsp);
            oCenCos.VM.CenCosGrupoId = SysData.ToLong(oCenCosVM.CenCosGrupoId);
            oCenCos.VM.EstadoId = SysData.ToLong(oCenCosVM.EstadoId);
        }

        private List<clsCenCosVM> CenCosGrid()
        {
            clsCenCosCarlos oCenCos = new clsCenCosCarlos(clsAppInfo.Connection);
            List<clsCenCosVM> oCenCosVM = new List<clsCenCosVM>();

            try
            {
                oCenCos.SelectFilter = clsCenCosCarlos.SelectFilters.Grid;
                oCenCos.WhereFilter = clsCenCosCarlos.WhereFilters.Grid;
                oCenCos.OrderByFilter = clsCenCosCarlos.OrderByFilters.Grid;

                if (oCenCos.Open())
                {
                    foreach (DataRow dr in oCenCos.DataSet.Tables[oCenCos.TableName].Rows)
                    {
                        oCenCosVM.Add(new clsCenCosVM()
                        {
                            CenCosId = SysData.ToLong(dr["CenCosId"]),
                            CenCosCod = SysData.ToStr(dr["CenCosCod"]),
                            CenCosDes = SysData.ToStr(dr["CenCosDes"]),
                            CenCosEsp = SysData.ToStr(dr["CenCosEsp"]),
                            CenCosGrupoId = SysData.ToLong(dr["CenCosGrupoId"]),
                            CenCosGrupoDes = SysData.ToStr(dr["CenCosGrupoDes"]),
                            EstadoId = SysData.ToLong(dr["EstadoId"]),
                            EstadoDes = SysData.ToStr(dr["EstadoDes"])
                        });
                    }
                }
            }

            catch (Exception exp)
            {
                throw (exp);

            }
            finally
            {
                oCenCos.Dispose();
            }

            return oCenCosVM;
        }

        private clsCenCosVM CenCosFind(long lngCenCosId)
        {
            clsCenCosCarlos oCenCos = new clsCenCosCarlos(clsAppInfo.Connection);
            clsCenCosVM oCenCosVM = new clsCenCosVM();

            try
            {
                oCenCos.VM.CenCosId = lngCenCosId;

                if (oCenCos.FindByPK())
                {
                    oCenCosVM.CenCosId =  oCenCos.VM.CenCosId;
                    oCenCosVM.CenCosCod = oCenCos.VM.CenCosCod;
                    oCenCosVM.CenCosDes = oCenCos.VM.CenCosDes;
                    oCenCosVM.CenCosEsp = oCenCos.VM.CenCosEsp;
                    oCenCosVM.CenCosGrupoId = oCenCos.VM.CenCosGrupoId;
                    oCenCosVM.EstadoId = oCenCos.VM.EstadoId;

                    return oCenCosVM;
                }
            }

            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                oCenCos.Dispose();
            }

            return null;
        }

    }
}