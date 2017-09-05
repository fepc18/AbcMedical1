using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Administracion
{
    [Table("PuestoAtencion")]

    public class PuestoAtencion
    {
        
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int PuestoAtencionId { get; set; }
        public int CompanyClientId { get; set; }
        public virtual CompanyClient CompanyClient { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Coordinador { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Teléfonos")]
        public string Telefonos { get; set; }
    }
}
