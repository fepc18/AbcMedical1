using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Administracion.Api;

namespace Action.Administracion
{
    public class RegistroClinicoAction
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public OutGetRegistros getRegistros(InGetRegistros Input)
        {
            var response = new OutGetRegistros();
            try
            {
                var master = db.RegistroClinico.ToList();
                if (master == null)
                {
                    response.State = false;
                    response.Message = "No hay registros clínicos creados.";                    
                }
                else
                {
                    response.State = true;
                    response.Message = "OK";
                    response.RegistrosClinicos = master;
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