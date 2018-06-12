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
            this.GetDefaultData();
            return View();
        }

        // POST: PlanGrupoTipoCarlos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(clsPlanGrupoTipoVMCarlos oPlanGrupoTipo)
        {
            this.GetDefaultData();
            try
            {
                if (ModelState.IsValid)
                {
                    clsPlanGrupoTipoCarlos oDAC = new clsPlanGrupoTipoCarlos(clsAppInfo.Connection);
                    oDAC.VM = oPlanGrupoTipo;

                    if (oDAC.Insert()) {
                        return RedirectToAction("Index");
                    }
                }

                return View(oPlanGrupoTipo);
            }
            catch(Exception exp)
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
    }
}
