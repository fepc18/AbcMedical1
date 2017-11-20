using System.ComponentModel.DataAnnotations;
using System.Web;
using Entities.Administracion;

namespace Entities.Administracion
{
    public class CargarFirma
    {
        public int ProfesionalId { get; set; }
        [Required(ErrorMessage = "Por favor seleccione un archivo.")]
        [RegularExpression(@"([a-zA-Z0-9\s_\\.\-:])+(.png)$", ErrorMessage = "Únicamente formato .png")]
        public HttpPostedFileBase Archivo { get; set; }
      
    }
}

