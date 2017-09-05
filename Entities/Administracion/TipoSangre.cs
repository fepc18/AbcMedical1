using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Administracion
{
    [Table("TipoSangre")]

    public class TipoSangre
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int TipoSangreId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
