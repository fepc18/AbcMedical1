using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Administracion;
namespace Entities.Historia
{
    [Table("RegistroHistoria")]

    public class RegistroHistoria
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int RegistroHistoriaId { get; set; }
        public int CompanyCLientId { get; set; }

        public int PacienteId { get; set; }
        public virtual Paciente Paciente { get; set; }
        public int RegistroClinicoId { get; set; }
        public string Asunto { get; set; }
        public DateTime Fecha { get; set; }
        public int UsuarioId { get; set; }
        public int ProfesionalId { get; set; }
        public int Diagnostico { get; set; }        
        public int DiagnosticoRelacionado1 { get; set; }
        public int DiagnosticoRelacionado2 { get; set; }
        public int DiagnosticoRelacionado3 { get; set; }
        public int DiagnosticoRelacionado4 { get; set; }
        public int DiagnosticoRelacionado5 { get; set; }
        public string Contenido { get; set; }
    }
}
