using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Historia.Api.Register
{
    public class Psiquiatria
    {
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string MotivoConsulta { get; set; }
        public string EnfermedadActual { get; set; }
        public string AntecedentesPersonales { get; set; }
        public string AntecedentesFamiliares { get; set; }
        public string PatronConsumo { get; set; }
        public string ExamenFisico { get; set; }
        public string ExamenMental { get; set; }
        public string Paraclinicos { get; set; }
        public string PrescripcionTratamiento { get; set; }
        public string EvolucionPertinencia { get; set; }

    }
}
