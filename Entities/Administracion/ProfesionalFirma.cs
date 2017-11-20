using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Seguridad;
namespace Entities.Administracion
{
    [Table("ProfesionalFirma")]
    public class ProfesionalFirma
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int ProfesionalFirmaId { get; set; }
        public int ProfesionalId { get; set; }
        public string Firma64 { get; set; }
    }
}


