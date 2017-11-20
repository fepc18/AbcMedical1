using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ArchivoDigital
{
    [Table("Archivo")]
    public class Archivo
    {
        public int ArchivoId { get; set; }
        public int CompanyClientId { get; set; }
        public String Nombre { get; set; }
        public int VolumenId { get; set; }
        public string TipoArchivo { get; set; }//(PDF,txt..etc)
        public int TipoAnexoId { get; set; }
        public int PacienteId { get; set; }
        public string Observacion { get; set; }
        public DateTime FechaOperacion { get; set; }
        public string Usuario { get; set; }


    }
    [Table("TipoAnexo")]
    public class TipoAnexo
    {
        public int TipoAnexoId { get; set; }
        public string Descripcion { get; set; }
        public int CompanyClientId { get; set; }
    }
}
