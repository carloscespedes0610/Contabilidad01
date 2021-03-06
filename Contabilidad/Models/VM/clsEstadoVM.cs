﻿using System.ComponentModel.DataAnnotations;

namespace Contabilidad.Models.VM
{
    public class clsEstadoVM
    {
        [Key]
        public long EstadoId { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "{0} es Requerido")]
        public string EstadoCod { get; set; }

        [Display(Name = "Tipo Usuario")]
        [Required(ErrorMessage = "{0} es Requerido")]
        public string EstadoDes { get; set; }

        [Display(Name = "Aplicación")]
        public long AplicacionId { get; set; }
    }
}