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
        [Key, Display(Name = "ID")]
        public long TipoPlanId { get; set; }

        [Required, StringLength(255), Display(Name ="Descripcion")]
        public string TipoPlanDes { get; set; }

        [Required, Display(Name = "Estado")]
        public long EstadoId { get; set; }

        [NotMapped, StringLength(255), Display(Name = "Estado")]
        public string EstadoDes { get; set; }

        public static string _TipoPlanId = nameof(TipoPlanId);
        public static string _TipoPlanDes = nameof(TipoPlanDes);
        public static string _EstadoId = nameof(EstadoId);
        public static string _EstadoDes = nameof(EstadoDes);

    }
}