using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Utilities;

namespace Entities.Administracion.Api
{
    public class PacienteResponse:Response
    {
        public Paciente paciente { get; set; }
    }
}
