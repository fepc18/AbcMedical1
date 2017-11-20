using System.ComponentModel.DataAnnotations;
using System.Web;
using Entities.Administracion;

namespace Entities.ArchivoDigital
{
    public class CargarArchivoDigital
    {
        public string Nombre { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int TipoAnexoId { get; set; }
        public TipoAnexo TipoAnexo { get; set; }
        [Required(ErrorMessage = "Por favor seleccione un archivo.")]        
        public HttpPostedFileBase Archivo { get; set; }
        public string Observacion { get; set; }
    }
}

