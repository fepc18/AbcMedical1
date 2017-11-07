using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Utilities;
namespace Entities.Historia.Api
{
    public class OutGetResumenRegistrosHistorial : Response
    {
        public List<ResumenRegistroHistorial> ResumenRegistroHistorial { get; set; }        
    }
}
