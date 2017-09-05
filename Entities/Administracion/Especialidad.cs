using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Administracion
{
    [Table("Especialidad")]

    public class Especialidad
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int EspecialidadId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int CompanyClientId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
