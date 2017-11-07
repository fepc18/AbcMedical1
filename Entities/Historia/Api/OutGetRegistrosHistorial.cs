using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Utilities;
namespace Entities.Historia.Api
{
    public class OutGetRegistrosHistorial : Response
    {
        public List<RegistroHistorial> RegistrosHistorial { get; set; }        
    }
}
