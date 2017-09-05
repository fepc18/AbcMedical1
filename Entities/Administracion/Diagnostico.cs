using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Administracion
{
    [Table("Diagnostico")]
    public class Diagnostico
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int DiagnosticoId { get; set; }
        public int CompanyClientId { get; set; }
        public virtual CompanyClient CompanyClient { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Edad Inferior")]
        public string EdadInferior { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Edad Superior")]
        public string EdadSuperior { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public Boolean Activo { get; set; }
    }
}
