using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.VM.Carlos
{
    public class clsPlanGrupoTipoFormVMCarlos
    {
        public ICollection<clsPlanGrupoTipoDetVMCarlos> PlanGrupoTipoDet { get; set; }

        public clsPlanGrupoTipoFormVMCarlos()
        {
            PlanGrupoTipoDet = new HashSet<clsPlanGrupoTipoDetVMCarlos>();
        }

        [Key]
        [Display(Name = "ID")]
        public long PlanGrupoTipoId { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Código")]
        public string PlanGrupoTipoCod { get; set; }

        [Required, StringLength(255)]
        [Display(Name = "Descripción")]
        public string PlanGrupoTipoDes { get; set; }

        [StringLength(255)]
        [Display(Name = "Especificación")]
        public string PlanGrupoTipoEsp { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public long EstadoId { get; set; }

        [NotMapped]
        [Display(Name = "Estado")]
        public string EstadoDes { get; set; }



    }
}