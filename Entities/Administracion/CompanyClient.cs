using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Administracion
{
    [Table("CompanyClient")]
    public class CompanyClient
    {
        public int CompanyClientId { get; set; }
        public string RazonSocial { get; set; }
    }
}
