using Contabilidad.Models.Modules;
using Contabilidad.Models.VM.Carlos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.InMemory
{
    public class clsPlanGrupoTipoDetIMCarlos
    {
        const string SessionKey = "clsPlanGrupoTipoDetVMCarlos";
        public long PlanGrupoTipoId { get; set; }

        public ICollection<clsPlanGrupoTipoDetVMCarlos> PlanGrupoTipoDetList {
            get
            {
                var session = HttpContext.Current.Session;
                if (session[SessionKey] == null) {
                    session[SessionKey] = ComboBox.PlanGrupoTipoDetCarlosList(PlanGrupoTipoId);
                }

                return (ICollection<clsPlanGrupoTipoDetVMCarlos>)session[SessionKey];
            }
        }

        public void SaveChanges()
        {
            foreach (var oPlanGrupoTipoDet in PlanGrupoTipoDetList.Where(a => a.PlanGrupoTipoDetId == 0))
            {
                oPlanGrupoTipoDet.PlanGrupoTipoDetId = PlanGrupoTipoDetList.Max(a => a.PlanGrupoTipoDetId) + 1;
            }
        }
    }
}