using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Historia.Api
{
    public class ResumenRegistroHistorial
    {
        public string RegistroClinicoId { get; set; }
        public string RegistroClinico { get; set; }
        public string Cantidad { get; set; }
    }
}
