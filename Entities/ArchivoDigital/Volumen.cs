using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ArchivoDigital
{
    [Table("Volumen")]
    public class Volumen
    {
        public int VolumenId { get; set; }
        public int CompanyClientId { get; set; }
        public String UrlVolumen { get; set; }

        public Boolean Activo { get; set; }
        public DateTime FechaCreacion { get; set; }
        public String Usuario { get; set; } 
    }
}
