using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Administracion;
namespace Entities.Seguridad
{
    [Table("Log")]
    public class Log
    {
        [Display(Name = "Id")]
        public int LogId { get; set; }
        public int CompanyClientId { get; set; }
        public virtual CompanyClient CompanyClient { get; set; }
        
        public DateTime Fecha { get; set; }
        public string Usuario { get; set; }
        public string Modulo { get; set; }
        public string Descripcion { get; set; }
        
    }
}
