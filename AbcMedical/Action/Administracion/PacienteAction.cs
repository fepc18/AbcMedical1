using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Administracion.Api;

namespace Action.Administracion
{
    public class PacienteAction
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public PacienteResponse getPaciente(string PacienteDocument)
        {
            var response = new PacienteResponse();
            try
            {
                var paciente = db.Pacientes.Where(x=>x.Identificacion==PacienteDocument).FirstOrDefault();
                if (paciente == null)
                {
                    response.State = false;
                    response.Message = "El paciente buscado no existe.";                    
                }
                else
                {
                    response.State = true;
                    response.Message = "OK";
                    response.paciente = paciente;
                }
                
            }
            catch(Exception ex)
            {
                response.State = false;
                response.Message = ex.Message;
            }
            
            return response;
        }
    }
}