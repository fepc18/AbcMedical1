using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Utilities;
using Entities.Historia;
namespace Entities.Administracion.Api
{
    public class OutGetRegistrosHistorial: Response
    {
        public List<RegistroHistoria> RegistrosClinicos { get; set; }        
    }
}
