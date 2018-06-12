using Contabilidad.Models.DAC;
using Contabilidad.Models.DAC.Carlos;
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
        // GET: PlanGrupoTipoCarlos
        public ActionResult Index()
        {
            this.GetDefaultData();

            return View();
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

            if (oDAC.Open()) {
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

        // GET: PlanGrupoTipoCarlos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanGrupoTipoCarlos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPlanGrupoTipoVMCarlos nuevo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                    oDAC.VM = nuevo;

                    if (oDAC.Insert()) {
                        return RedirectToAction("Index");
                    }
                }

                return View(nuevo);
            }
            catch(Exception exp)
            {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: PlanGrupoTipoCarlos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanGrupoTipoCarlos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanGrupoTipoCarlos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanGrupoTipoCarlos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
