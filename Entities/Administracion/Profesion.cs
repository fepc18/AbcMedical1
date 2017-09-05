using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Administracion
{
    [Table("Profesion")]
    public class Profesion
    {
        public int ProfesionId { get; set; }
        public int CompanyClientId { get; set; }
        public virtual CompanyClient CompanyClient { get; set; }
        public string Descripcion { get; set; }
    }
}
