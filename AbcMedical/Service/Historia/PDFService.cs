using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Historia.Api.Register;
using Newtonsoft.Json;
using System.IO;
namespace AbcMedical.Service.Historia
{
    public class PDFService
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public String PDFRegistroHistoria(string _RegistroHistoriaId)
        {
            var RegistroHistoria = db.RegistroHistoria.Where(x => x.RegistroHistoriaId.ToString() == _RegistroHistoriaId).FirstOrDefault();
            var RegistroClinico = db.RegistroClinico.Find(RegistroHistoria.RegistroClinicoId);
            string html = string.Empty;
            if (RegistroClinico.Controller.ToUpper().Equals("NOTA")){
                html = getNota(RegistroHistoria, RegistroClinico);
            }
            else if (RegistroClinico.Controller.ToUpper().Equals("PSICOLOGIA"))
            {
                html = getPsicologia(RegistroHistoria, RegistroClinico);
            }
            return html;


        }

        public string getNota(Entities.Historia.RegistroHistoria RegistroHistoria, Entities.Administracion.RegistroClinico RegistroClinico)
        {
           
            var Nota = JsonConvert.DeserializeObject<Nota>(RegistroHistoria.Contenido);

            String HTML = "";

            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableContent {border: 1px dotted black;valign:top; vertical-align:top; padding: 10px; text-align:justify;border-collapse: separate; font-family:Arial;} .tableContent.th, .tableContent.td { vertical-align:top; padding: 5px; text-align:justify;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style>";
            HTML += cabeceraReporte(RegistroClinico.Descripcion);
            HTML += cabeceraPaciente(RegistroHistoria.PacienteId);
            //DATOS DEL REPORTE
            HTML += "<br/>";
            HTML += "<center><table  width='900px' class='tableContent'> "; 
            HTML += "<tr>";
            HTML += "<td><b>Asunto:</b></td>";
            HTML += "<td>" + Nota.Asunto + "</td>";
            HTML += "<td><b>Fecha:</b></td>";
            HTML += "<td>" + Nota.Fecha + " - " + Nota.Hora + "</td>";
            HTML += "</tr><tr>";
            HTML += "<td ><b>Descripción:</b></td>";
            HTML += "<td colspan='3'>" + Nota.Descripcion + "</td>";
            HTML += "</table>";
            HTML += firmaReporte(RegistroHistoria.ProfesionalId);
            return HTML;
        }
        public string getPsicologia(Entities.Historia.RegistroHistoria RegistroHistoria, Entities.Administracion.RegistroClinico RegistroClinico)
        {

            var Psicologia = JsonConvert.DeserializeObject<Psicologia>(RegistroHistoria.Contenido);

            String HTML = "";

            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableContent {border: 1px dotted black;valign:top; vertical-align:top; padding: 10px; text-align:justify;border-collapse: separate; font-family:Arial;} .tableContent.th, .tableContent.td { vertical-align:top; padding: 5px; text-align:justify;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style>";
            HTML += cabeceraReporte(RegistroClinico.Descripcion.ToUpper());
            HTML += cabeceraPaciente(RegistroHistoria.PacienteId);
            //DATOS DEL REPORTE
            HTML += "<br/>";
            HTML += "<center><table  width='900px' class='tableContent'> ";
            HTML += "<tr>";
            HTML += "<td><b>Fecha:</b></td>";
            HTML += "<td>" + Psicologia.Fecha + " - " + Psicologia.Hora + "</td>";
            HTML += "</tr><tr>";
            HTML += "<td ><b>Acompañante:</b></td>";
            HTML += "<td>" + Psicologia.Acompanante + "</td>";
            HTML += "<td ><b>Parentesco:</b></td>";
            HTML += "<td>" + Psicologia.Parentesco + "</td>";
            HTML += "</table>";
            HTML += firmaReporte(RegistroHistoria.ProfesionalId);
            return HTML;
        }

        public String cabeceraReporte(String NombreReporte)
        {
            // Customer customer = db.Customer.Where(x => x.CustomerId == 1).FirstOrDefault();
            String RazonSocial = "Salud Metal en Casa";// customer.RazonSocial;
            String Nit = "27093275-8";// customer.Nit;
            String Direccion = "Calle 152a # 13 - 58";// customer.Nit;
            String Telefonos = "300 357 87 76 - (1) 7 32 51 51";// customer.Nit;
            String rootPath = HttpContext.Current.Server.MapPath("/Content/Images/logo-reportes");
            //LOGO IZQUIERDA
            String left = "";
            var pathSource=rootPath + "\\izquierda.png";

            using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fsSource.Length];
                fsSource.Read(bytes, 0, (int)fsSource.Length);
                left = Convert.ToBase64String(bytes);
            }
            //LOGO DERECHA
            String right = "";
             pathSource=rootPath + "\\derecha.png";

            using (FileStream fsSource = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
            {
                byte[] bytes = new byte[fsSource.Length];
                fsSource.Read(bytes, 0, (int)fsSource.Length);
                right = Convert.ToBase64String(bytes);
            }
            

            String HTML = "<br/>";
            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableDetalle { font-family:Arial;padding: 10px;} .tableDetalle.th, .tableDetalle.td {cellpadding:5px;cellspacing:5px;border: 1px dotted black; padding: 10px; text-align:left;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style><body>";
            HTML += "<table  width='900px' class='tableDetalle'>";
            HTML += "<tr>";
            HTML += "<td><img style='display:block; height:100px;' id='base64image' src = 'data:image/png;base64,"+left+"' /></td>";
            HTML += "<td><center><b><SPAN style='font-family:Arial; font-size: 18pt'>" + RazonSocial + "</span></b></center><center><span style='font-family: Arial; font-size: 12pt'><b>Nit: </b>" + Nit + "</span></center><center><span style='font-family: Arial; font-size: 12pt'><b>Dirección: </b>" + Direccion + " <b>Teléfonos: </b>" + Telefonos + "</span></center></td>";
            HTML += "<td><img style='display:block; height:100px;' id='base64image' src = 'data:image/png;base64,"+ right + "' /></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td></td>";
            HTML += "</tr>";

            HTML += "<tr>";
            HTML += "<td></td>";
            HTML += "<td><br/><center><b><SPAN STYLE='font-family: Arial; font-size: 18pt'>" + NombreReporte + "</SPAN></b></center></td>";
            HTML += "<td></td>";
            HTML += "</tr>";
            HTML += "</table>";
            return HTML;
        }
        public String cabeceraPaciente(int _PacienteId)
        {

            var Paciente = db.Pacientes.Find(_PacienteId);



            String HTML = "<br/><br/>";
            HTML += "<table  width='900px'  class='tableDetalle'>";
            HTML += "<tr>";
            HTML += "<td><b><SPAN STYLE='font - family: Arial; font-size: 12pt'>Paciente</SPAN></b></td>";
            HTML += "<td><SPAN STYLE='font - family: Arial; font-size: 12pt'>" + Paciente.PrimerNombre + " " + Paciente.SegundoNombre + " " + Paciente.PrimerApellido + " " + Paciente.SegundoApellido + "</SPAN></b></td>";
            HTML += "<td><b><SPAN STYLE='font - family: Arial; font-size: 12pt'>Identificación</SPAN></b></td>";
            HTML += "<td><SPAN STYLE='font - family: Arial; font-size: 12pt'>" + Paciente.TipoIdentificacion.Abreviatura + " - " + Paciente.Identificacion + "</SPAN></b></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b><SPAN STYLE='font - family: Arial; font-size: 12pt'>Dirección</SPAN></b></td>";
            HTML += "<td><SPAN STYLE='font - family: Arial; font-size: 12pt'>" + Paciente.Direccion + "</SPAN></b></td>";
            HTML += "<td><b><SPAN STYLE='font - family: Arial; font-size: 12pt'>Teléfonos</SPAN></b></td>";
            HTML += "<td><SPAN STYLE='font - family: Arial; font-size: 12pt'>" + Paciente.TelefonoResidencia + " - " + Paciente.Celular + "</SPAN></b></td>";
            HTML += "</tr>";
            HTML += "</table>";
            return HTML;
        }
        public String firmaReporte(int _ProfesionalId)
        {
            var Profesional = db.Profesionals.Find(_ProfesionalId);



            String HTML = "<br/><br/><br/>";
            HTML += "<table  width='900px'  class='tableDetalle'>";
            HTML += "<tr>";
            HTML += "<td>Firma</td>";
            HTML += "</tr><tr>";
            HTML += "<td><b><SPAN STYLE='font - family: Arial; font-size: 12pt'>" + Profesional.PrimerNombre + " " + Profesional.SegundoNombre + " " + Profesional.PrimerApellido + " " + Profesional.SegundoApellido + "</SPAN></b></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b><SPAN STYLE='font - family: Arial; font-size: 12pt'>Numero Registro/TP: " + Profesional.NumeroRegistro + "</SPAN></b></td>";
            HTML += "</tr>";
            HTML += "</table>";
            return HTML;
        }
    }

}