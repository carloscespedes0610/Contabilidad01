using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidad.Controllers.Carlos
{
    [SessionExpireFilter]
    public class PlanGrupoTipoDetController : Controller
    {
        // GET: PlanGrupoTipoDet
        public ActionResult Index()
        {
            return View();
        }

        // GET: PlanGrupoTipoDet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlanGrupoTipoDet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanGrupoTipoDet/Create
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

        // GET: PlanGrupoTipoDet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanGrupoTipoDet/Edit/5
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

        // GET: PlanGrupoTipoDet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanGrupoTipoDet/Delete/5
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
