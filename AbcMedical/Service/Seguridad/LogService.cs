using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Historia.Api.Register;
using Newtonsoft.Json;
using System.IO;
using Entities.Seguridad;
namespace AbcMedical.Service.Seguridad
{
    public class LogService
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public void RegisterLog(Log log)
        {
            try
            {
                db.Logs.Add(log);
                db.SaveChanges();
            }
            catch(Exception ex)
            {

            }
            
        }
    }

}