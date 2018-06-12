using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.VM.Carlos
{
    public class clsPlanGrupoTipoVMCarlos
    {
        [Key, Display(Name = "Id")]
        public long PlanGrupoTipoId { get; set; }

        [Required, StringLength(50)]
        [Display(Name = "Código" )]
        [DataType(DataType.Text)]
        public string PlanGrupoTipoCod { get; set; }

        [Required, StringLength(255)]
        [Display(Name = "Descripción")]
        [DataType(DataType.Text)]
        public string PlanGrupoTipoDes { get; set; }

        [StringLength(255)]
        [Display(Name = "Especificación")]
        [DataType(DataType.Text)]
        public string PlanGrupoTipoEsp { get; set; }

        [Required]
        [Display(Name = "Estado")]
        [Range(1, long.MaxValue, ErrorMessage = "{0} es Requerido")]
        public long EstadoId { get; set; }

        [NotMapped]
        [Display(Name ="Estado")]
        public string EstadoDes { get; set; }


        public static string _PlanGrupoTipoId = nameof(PlanGrupoTipoId);
        public static string _PlanGrupoTipoCod = nameof(PlanGrupoTipoCod);
        public static string _PlanGrupoTipoDes = nameof(PlanGrupoTipoDes);
        public static string _PlanGrupoTipoEsp = nameof(PlanGrupoTipoEsp);
        public static string _EstadoId = nameof(EstadoId);
        public static string _EstadoDes = nameof(EstadoDes);
    }
}