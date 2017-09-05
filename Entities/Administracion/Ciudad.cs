using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Administracion
{
    [Table("Ciudad")]
    public class Ciudad
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int CiudadId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Departamento")]
        public int DepartamentoId { get; set; }
        public virtual Departamento Departamento { get; set; }

    }
}
