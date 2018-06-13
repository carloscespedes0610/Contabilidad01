using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.VM.Carlos
{
    public class clsPlanGrupoTipoDetVMCarlos
    {
        [Key]
        public long PlanGrupoTipoDetId { get; set; }

        [Required, Display(Name = "Tipo Plan Grupo")]
        public long PlanGrupoTipoId { get; set; }

        [Required,StringLength(50), Display(Name = "Codigo")]
        public string PlanGrupoTipoDetCod { get; set; }

        [Required, StringLength(255), Display(Name ="Descripcion")]
        public string PlanGrupoTipoDetDes{ get; set; }

        [Required, StringLength(255), Display(Name = "Especificación")]
        public string PlanGrupoTipoDetEsp { get; set; }

        [Required]
        public long EstadoId { get; set; }

        [NotMapped]
        public string EstadoDes { get; set; }

        [NotMapped]
        public string PlanGrupoTipoDes { get; set; }

        public static string _PlanGrupoTipoDetId = nameof(PlanGrupoTipoDetId);
        public static string _PlanGrupoTipoId = nameof(PlanGrupoTipoId);
        public static string _PlanGrupoTipoDetCod = nameof(PlanGrupoTipoDetCod);
        public static string _PlanGrupoTipoDetDes = nameof(PlanGrupoTipoDetDes);
        public static string _PlanGrupoTipoDetEsp = nameof(PlanGrupoTipoDetEsp);
        public static string _EstadoId = nameof(EstadoId);
        public static string _EstadoDes = nameof(EstadoDes);
        public static string _PlanGrupoTipoDes = nameof(PlanGrupoTipoDes);

    }
}