using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidad.Models.VM.Carlos
{
    public class clsTipoPlanVMCarlos
    {
        [Key]
        public long TipoPlanId { get; set; }

        [Required, StringLength(255), Display(Name ="Descripcion")]
        public string TipoPlanDes { get; set; }

        [Required, Display(Name = "EstadoId")]
        public int EstadoId { get; set; }

        [NotMapped, StringLength(255), Display(Name = "Estado")]
        public string EstadoDes { get; set; }

        public static string var_TipoPlanId = nameof(TipoPlanId);
        public static string var_TipoPlanDes = nameof(TipoPlanDes);
        public static string var_EstadoId = nameof(EstadoId);
        public static string var_EstadoDes = nameof(EstadoDes);

    }
}