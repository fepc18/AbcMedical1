using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Utilities;
namespace Entities.Historia.Api
{
    public class InGetRegistrosHistorial 
    {
        public int PacienteId { get; set; }
        public int RegistroClinicoId { get; set; }
        public int CompanyClientId { get; set; }
        public int UserId { get; set; }
    }
}
