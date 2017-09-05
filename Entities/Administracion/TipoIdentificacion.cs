using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Administracion
{
    [Table("TipoIdentificacion")]
    public class TipoIdentificacion
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int TipoIdentificacionId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Abreviatura { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Descripcion { get; set; }
    }
}
