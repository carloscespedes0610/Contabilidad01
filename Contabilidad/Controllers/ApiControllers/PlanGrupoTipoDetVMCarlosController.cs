using Contabilidad.Models.InMemory;
using Contabilidad.Models.Modules;
using Contabilidad.Models.VM;
using Contabilidad.Models.VM.Carlos;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;

namespace Contabilidad.Controllers.ApiControllers
{
    public class PlanGrupoTipoDetVMCarlosController : ApiController
    {
        clsPlanGrupoTipoDetIMCarlos db = new clsPlanGrupoTipoDetIMCarlos();
        clsPlanGrupoTipoDetIMCarlos dbDel = new clsPlanGrupoTipoDetIMCarlos();

        [HttpGet]
        public HttpResponseMessage Get(DataSourceLoadOptions loadOptions, int? id)
        {
            db.PlanGrupoTipoId = SysData.ToInteger(id);
            return Request.CreateResponse(DataSourceLoader.Load(db.PlanGrupoTipoDetList, loadOptions));
        }

        [HttpPost]
        public HttpResponseMessage Post(FormDataCollection form)
        {
            var values = form.Get("values");

            var oPlanGrupoTipoDetVM = new clsPlanGrupoTipoDetVMCarlos();
            JsonConvert.PopulateObject(values, oPlanGrupoTipoDetVM);

            Validate(oPlanGrupoTipoDetVM);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error HttpResponseMessage Post");

            db.PlanGrupoTipoDetList.Add(oPlanGrupoTipoDetVM);
            //db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage Put(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var values = form.Get("values");
            var oPlanGrupoDetVM = db.PlanGrupoTipoDetList.First(e => e.PlanGrupoTipoDetId== key);

            JsonConvert.PopulateObject(values, oPlanGrupoDetVM);

            Validate(oPlanGrupoDetVM);
            if (!ModelState.IsValid)
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Error HttpResponseMessage Put");

            //db.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public void Delete(FormDataCollection form)
        {
            var key = Convert.ToInt32(form.Get("key"));
            var oPlanGrupoDetVM = db.PlanGrupoTipoDetList.First(e => e.PlanGrupoTipoDetId == key);

            dbDel.PlanGrupoTipoDetList.Add(oPlanGrupoDetVM);

            db.PlanGrupoTipoDetList.Remove(oPlanGrupoDetVM);
            db.SaveChanges();
        }

    }
}