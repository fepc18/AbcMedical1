using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Administracion.Reportes
{
    public class FiltrosHistoriasCreadas
    {
        [Required(ErrorMessage = "Campo Requerido")]
        public int PuestoAtencionId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int ProfesionalId { get; set; }
        public int DiagnosticoId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaInicio { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime FechaFin { get; set; }
    }
}
