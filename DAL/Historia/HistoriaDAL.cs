using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Historia.Api;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
namespace DAL.Historia
{
    public class HistoriaDAL
    {
        public OutGetRegistrosHistorial GetRegistrosHistorial(InGetRegistrosHistorial Input)
        {
            //var response = new ResponseServices<List<MasterBue>>();

            var connectionString = ConfigurationManager.ConnectionStrings["AbcMedicalContext"].ConnectionString;
            var response = new OutGetRegistrosHistorial();
            try
            {
                var conn = new MySqlConnection(connectionString);


                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandTimeout = 0;
                command.Connection = conn;

                var PI_PacienteId = new MySqlParameter("_PacienteId",Input.PacienteId);
                var PI_RegistroClinicoId = new MySqlParameter("_registroClinicoId", Input.RegistroClinicoId);
                command.Parameters.Add(PI_PacienteId);
                command.Parameters.Add(PI_RegistroClinicoId);

                command.CommandText = "getRegistrosHistorial";
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataReader datos = command.ExecuteReader();

                var list = new List<RegistroHistorial>();
                int numeroFila = 0;
                while (datos.Read())
                {
                    if (numeroFila == 1)
                        numeroFila = 2;
                    else
                        numeroFila = 1;
                    var master = new RegistroHistorial
                    {
                        NumeroFila= numeroFila,
                        RegistroHistoriaId = datos["RegistroHistoriaId"].ToString(),
                        Asunto = datos["Asunto"].ToString(),
                        Fecha = datos["Fecha"].ToString().Substring(0,10),
                        Hora = datos["Hora"].ToString(),
                        Profesional = datos["Profesional"].ToString(),
                        RegistroClinico = datos["RegistroClinico"].ToString()                      
                    };
                    list.Add(master);
                  
                }
                response.RegistrosHistorial = list.OrderByDescending(x=>x.RegistroHistoriaId).ToList();
                response.State = true;
                response.Message = "OK";
                datos.Close();
                command.Dispose();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                 response.State = false;                 
                 response.Message = ex.Message;
            }
            return response;
        }

        public OutGetResumenRegistrosHistorial GetResumenRegistrosHistorial(InGetRegistrosHistorial Input)
        {
            //var response = new ResponseServices<List<MasterBue>>();

            var connectionString = ConfigurationManager.ConnectionStrings["AbcMedicalContext"].ConnectionString;
            var response = new OutGetResumenRegistrosHistorial();
            try
            {
                var conn = new MySqlConnection(connectionString);


                conn.Open();
                MySqlCommand command = new MySqlCommand();
                command.CommandTimeout = 0;
                command.Connection = conn;

                var PI_PacienteId = new MySqlParameter("_PacienteId", Input.PacienteId);
                command.Parameters.Add(PI_PacienteId);

                command.CommandText = "getResumenRegistrosHistorial";
                command.CommandType = CommandType.StoredProcedure;

                MySqlDataReader datos = command.ExecuteReader();

                var list = new List<ResumenRegistroHistorial>();
                while (datos.Read())
                {
                    var master = new ResumenRegistroHistorial
                    {
                        RegistroClinicoId = datos["RegistroClinicoId"].ToString(),
                        RegistroClinico = datos["RegistroClinico"].ToString(),
                        Cantidad = datos["Cantidad"].ToString()
                    };
                    list.Add(master);

                }
                response.ResumenRegistroHistorial = list;
                response.State = true;
                response.Message = "OK";
                datos.Close();
                command.Dispose();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                response.State = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
