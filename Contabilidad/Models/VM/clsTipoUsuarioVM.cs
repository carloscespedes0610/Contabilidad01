using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contabilidad.Models.VM
{
    public class clsTipoUsuarioVM
    {
        [Key]
        public long TipoUsuarioId { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "{0} es Requerido")]
        public string TipoUsuarioCod { get; set; }

        [Display(Name = "Tipo Usuario")]
        [Required(ErrorMessage = "{0} es Requerido")]
        public string TipoUsuarioDes { get; set; }

        [Display(Name = "Estado")]
        public long EstadoId { get; set; }

        [NotMapped]
        [Display(Name = "Estado")]
        public string EstadoDes { get; set; }
    }
}