using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Historia.Api
{
    

    public class RegistroHistorial
    {
        public int NumeroFila { get; set; }
        public string RegistroHistoriaId { get; set; }
        public int RegistroClinicoId { get; set; }
        public string RegistroClinico { get; set; }
        public string Asunto { get; set; }
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public int ProfesionalId { get; set; }
        public string Profesional { get; set; }
        public string Diagnostico { get; set; }
        
    }
}
