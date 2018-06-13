using Contabilidad.Models.DAC;
using Contabilidad.Models.DAC.Carlos;
using Contabilidad.Models.Modules;
using Contabilidad.Models.VM.Carlos;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidad.Controllers.Carlos
{
    [SessionExpireFilter]
    public class PlanGrupoTipoCarlosController : Controller
    {
        string SessionKey = "clsPlanGrupoTipoDetVMCarlos";

        // GET: PlanGrupoTipoCarlos
        public ActionResult Index()
        {
            return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Index prohibido" });
        }

        // GET: PlanGrupoTipoCarlos/Create
        public ActionResult Create()
        {
            this.GetDefaultData();
            try
            {
                clsPlanGrupoTipoFormVMCarlos oPlanGrupoTipoFormVM = new clsPlanGrupoTipoFormVMCarlos();
                Session[SessionKey] = null;

                DataInit(oPlanGrupoTipoFormVM);
                ViewBagLoad();

                return View(oPlanGrupoTipoFormVM);


            }
            catch (Exception)
            {

                throw;
            }

        }

        // POST: PlanGrupoTipoCarlos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPlanGrupoTipoFormVMCarlos oPlanGrupoTipoForm)
        {
            this.GetDefaultData();
            try
            {
                if (ModelState.IsValid)
                {
                    clsPlanGrupoTipoCarlos oPlanGrupoTipo = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                    clsPlanGrupoTipoDetCarlos oPlanGrupoTipoDet = new clsPlanGrupoTipoDetCarlos(clsAppInfo.Connection);
                    long lngRowCount = 0;

                    DataMove(oPlanGrupoTipoForm, oPlanGrupoTipo, false);
                    oPlanGrupoTipo.BeginTransaction();

                    if (oPlanGrupoTipo.Insert())
                    {
                        var oPlanGrupoTipoDetVMList = (List<clsPlanGrupoTipoDetVMCarlos>)Session[SessionKey];
                      //  oPlanGrupoTipo.VM.PlanGrupoTipoId = oPlanGrupoTipo.Id;
                        oPlanGrupoTipoDet.Transaction = oPlanGrupoTipo.Transaction;

                        foreach (clsPlanGrupoTipoDetVMCarlos oPlanGrupoDetVM in oPlanGrupoTipoDetVMList)
                        {
                            DataMoveDet(oPlanGrupoTipo, oPlanGrupoDetVM, oPlanGrupoTipoDet, false);

                            if (oPlanGrupoTipoDet.Insert())
                            {
                                lngRowCount += 1;
                            }
                        }

                        if (oPlanGrupoTipoDetVMList.Count == lngRowCount)
                        {
                            oPlanGrupoTipo.Commit();
                            Session[SessionKey] = null;
                            return RedirectToAction("Index");
                        }
                    }

                    oPlanGrupoTipo.Rollback();
                }

                ViewBagLoad();
                return View(oPlanGrupoTipoForm);
            }
            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // --------------------------------------***********************************************************************************************---------------------




        // GET: PlanGrupoTipoCarlos/Details/5
        public ActionResult Details(int? id)
        {
            this.GetDefaultData();

            try
            {
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                clsPlanGrupoTipoVMCarlos VM = oDAC.FindByPK(SysData.ToLong(id));

                if (ReferenceEquals(VM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "no encontrado" });
                }

                return View(VM);
            }
            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }

        }

       
        // GET: PlanGrupoTipoCarlos/Edit/5
        public ActionResult Edit(int? id)
        {
            this.GetDefaultData();
            try
            {
                if (ReferenceEquals(id, null)) {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "indice nulo o no encontrado" });
                }

                clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                clsPlanGrupoTipoVMCarlos oVM = oDAC.FindByPK(SysData.ToLong(id));

                if (ReferenceEquals(oVM, null)) {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "no encontrado" });
                }

                return View(oVM);

            }
            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: PlanGrupoTipoCarlos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(clsPlanGrupoTipoVMCarlos oPlanGrupoTipo)
        {
            this.GetDefaultData();
            try
            {
                if (ModelState.IsValid) {
                    clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                    oDAC.VM = oPlanGrupoTipo;
                    if (oDAC.Update()) {
                        return RedirectToAction("Details",new { id = oPlanGrupoTipo.PlanGrupoTipoId });
                    }
                }
                return View(oPlanGrupoTipo);
            }
            catch(Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: PlanGrupoTipoCarlos/Delete/5
        public ActionResult Delete(int? id)
        {
            this.GetDefaultData();
            try
            {
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "indice nulo o no encontrado" });
                }

                clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                clsPlanGrupoTipoVMCarlos oVM = oDAC.FindByPK(SysData.ToLong(id));

                if (ReferenceEquals(oVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "no encontrado" });
                }

                return View(oVM);

            }
            catch (Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // POST: PlanGrupoTipoCarlos/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            this.GetDefaultData();
            try
            {
               
                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                oDAC.VM.PlanGrupoTipoId = SysData.ToLong(id);

                if (oDAC.Delete())
                {
                    return RedirectToAction("Index");
                }

                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Error al Eliminar el Registro" });

            }
            catch(Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        [HttpGet]
        public ActionResult PlanGrupoTipoGrid(DataSourceLoadOptions loadOptions)
        {
            return Content(JsonConvert.SerializeObject(PlanGrupoTipoGrid()), "application/json");
        }

        private List<clsPlanGrupoTipoVMCarlos> PlanGrupoTipoGrid()
        {
            List<clsPlanGrupoTipoVMCarlos> list = new List<clsPlanGrupoTipoVMCarlos>();
            clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
            oDAC.SelectFilter = clsPlanGrupoTipoCarlos.SelectFilters.Grid;
            oDAC.WhereFilter = clsPlanGrupoTipoCarlos.WhereFilters.Grid;
            oDAC.OrderByFilter = clsPlanGrupoTipoCarlos.OrderByFilters.Grid;

            if (oDAC.Open())
            {
                foreach (DataRow dr in oDAC.DataSet.Tables[oDAC.TableName].Rows)
                {
                    list.Add(new clsPlanGrupoTipoVMCarlos()
                    {
                        PlanGrupoTipoId = SysData.ToLong(dr[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoId]),
                        PlanGrupoTipoCod = SysData.ToStr(dr[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoCod]),
                        PlanGrupoTipoDes = SysData.ToStr(dr[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoDes]),
                        PlanGrupoTipoEsp = SysData.ToStr(dr[clsPlanGrupoTipoVMCarlos._PlanGrupoTipoEsp]),
                        EstadoId = SysData.ToLong(dr[clsPlanGrupoTipoVMCarlos._EstadoId]),
                        EstadoDes = SysData.ToStr(dr[clsPlanGrupoTipoVMCarlos._EstadoDes])
                    });
                }
            }
            return list;
        }

        private void DataInit(clsPlanGrupoTipoFormVMCarlos oPlanGrupoTipoFormVM)
        {
            oPlanGrupoTipoFormVM.PlanGrupoTipoId = 0;
            oPlanGrupoTipoFormVM.PlanGrupoTipoCod = "";
            oPlanGrupoTipoFormVM.PlanGrupoTipoDes = "";
            oPlanGrupoTipoFormVM.PlanGrupoTipoEsp = "";
            oPlanGrupoTipoFormVM.EstadoId = ConstEstado.Activo;
        }

        private void ViewBagLoad()
        {
            ViewBag.EstadoId = ComboBox.EstadoList();
        }

        private void DataMove(clsPlanGrupoTipoFormVMCarlos oPlanGrupoTipoFormVM, clsPlanGrupoTipoCarlos oPlanGrupoTipo, bool boolEditing)
        {
            if (boolEditing)
            {
                oPlanGrupoTipo.VM.PlanGrupoTipoId = SysData.ToLong(oPlanGrupoTipoFormVM.PlanGrupoTipoId);
            }

            oPlanGrupoTipo.VM.PlanGrupoTipoCod = SysData.ToStr(oPlanGrupoTipoFormVM.PlanGrupoTipoCod);
            oPlanGrupoTipo.VM.PlanGrupoTipoDes = SysData.ToStr(oPlanGrupoTipoFormVM.PlanGrupoTipoDes);
            oPlanGrupoTipo.VM.PlanGrupoTipoEsp = SysData.ToStr(oPlanGrupoTipoFormVM.PlanGrupoTipoEsp);
            oPlanGrupoTipo.VM.EstadoId = SysData.ToLong(oPlanGrupoTipoFormVM.EstadoId);
        }

        private void DataMoveDet(clsPlanGrupoTipoCarlos oPlanGrupoTipoDAC, clsPlanGrupoTipoDetVMCarlos oPlanGrupoTipoDetVM, clsPlanGrupoTipoDetCarlos oPlanGrupoTipoDetDAC, bool boolEditing)
        {
            if (boolEditing)
            {
                oPlanGrupoTipoDetDAC.VM.PlanGrupoTipoDetId = SysData.ToLong(oPlanGrupoTipoDetVM.PlanGrupoTipoDetId);
            }

            oPlanGrupoTipoDetDAC.VM.PlanGrupoTipoDetCod = SysData.ToStr(oPlanGrupoTipoDetVM.PlanGrupoTipoDetCod);
            oPlanGrupoTipoDetDAC.VM.PlanGrupoTipoDetDes = SysData.ToStr(oPlanGrupoTipoDetVM.PlanGrupoTipoDetDes);
            oPlanGrupoTipoDetDAC.VM.PlanGrupoTipoDetEsp = SysData.ToStr(oPlanGrupoTipoDetVM.PlanGrupoTipoDetEsp);
            oPlanGrupoTipoDetDAC.VM.PlanGrupoTipoId = SysData.ToLong(oPlanGrupoTipoDAC.VM.PlanGrupoTipoId);
            oPlanGrupoTipoDetDAC.VM.EstadoId = SysData.ToLong(oPlanGrupoTipoDAC.VM.EstadoId);

        }
    }
}
