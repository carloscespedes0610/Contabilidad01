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
    public class TipoPlanCarlosController : Controller
    {
        private clsTipoPlanCarlos oDAC = new clsTipoPlanCarlos(clsAppInfo.Connection);

        // GET: TipoPlanCarlos
        public ActionResult Index()
        {
            this.GetDefaultData();
            return View();
        }

        [HttpGet]
        public ActionResult TipoPlanGrid(DataSourceLoadOptions loadOptions)
        {
            return Content(JsonConvert.SerializeObject(TipoPlanGrid()), "application/json");
        }


        private List<clsTipoPlanVMCarlos> TipoPlanGrid()
        {
            List<clsTipoPlanVMCarlos> list = new List<clsTipoPlanVMCarlos>();

            
            oDAC.SelectFilter = clsTipoPlanCarlos.SelectFilters.Grid;
            oDAC.WhereFilter = clsTipoPlanCarlos.WhereFilters.Grid;
            oDAC.OrderByFilter = clsTipoPlanCarlos.OrderByFilters.Grid;

            if (oDAC.Open())
            {
                foreach (DataRow dr in oDAC.DataSet.Tables[oDAC.TableName].Rows)
                {
                    list.Add(new clsTipoPlanVMCarlos()
                    {
                        TipoPlanId = SysData.ToLong(dr[clsTipoPlanVMCarlos._TipoPlanId]),
                        TipoPlanDes = SysData.ToStr(dr[clsTipoPlanVMCarlos._TipoPlanDes]),
                        EstadoId = SysData.ToLong(dr[clsTipoPlanVMCarlos._EstadoId]),
                        EstadoDes = SysData.ToStr(dr[clsTipoPlanVMCarlos._EstadoDes])
                    });
                }
            }
            return list;
        }


        // GET: TipoPlanCarlos/Details/5
        public ActionResult Details(int id)
        {
            this.GetDefaultData();

            try
            {

                if (ReferenceEquals(id, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Índice nulo o no encontrado" });
                }

                clsTipoPlanVMCarlos oVM = oDAC.FindByPK(SysData.ToLong(id));

                if (ReferenceEquals(oVM, null))
                {
                    return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = "Tipo de Plan no encontrado" });
                }

                return View(oVM);

            }
            catch (Exception exp) {
                return RedirectToAction("httpErrorMsg", "Error", new { MessageErr = exp.Message });
            }
        }

        // GET: TipoPlanCarlos/Create
        public ActionResult Create()
        {
            this.GetDefaultData();

            return View();
        }

        // POST: TipoPlanCarlos/Create
        [HttpPost]
        public ActionResult Create(clsTipoPlanVMCarlos oTipoPlan)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TipoPlanCarlos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TipoPlanCarlos/Edit/5
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

        // GET: TipoPlanCarlos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TipoPlanCarlos/Delete/5
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
