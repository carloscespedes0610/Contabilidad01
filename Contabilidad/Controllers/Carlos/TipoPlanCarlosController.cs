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
        // GET: TipoPlanCarlos
        public ActionResult Index()
        {
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

            clsTipoPlanCarlos oDAC = new clsTipoPlanCarlos(clsAppInfo.Connection);
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
            return View();
        }

        // GET: TipoPlanCarlos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPlanCarlos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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
