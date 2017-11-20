using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.ArchivoDigital
{
    [Table("AnexoPaciente")]
    public class AnexoPaciente
    {
        public int AnexoPacienteId { get; set; }
        public long PacienteId { get; set; }

        public long ArchivoDigitalId { get; set; }
        
    }
    
}
