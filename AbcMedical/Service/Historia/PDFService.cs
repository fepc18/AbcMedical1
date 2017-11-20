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
            else if (RegistroClinico.Controller.ToUpper().Equals("TERAPIAOCUPACIONAL"))
            {
                html = getTerapiaOcupacional(RegistroHistoria, RegistroClinico);
            }
            else if (RegistroClinico.Controller.ToUpper().Equals("PSIQUIATRIA"))
            {
                html = getPsiquiatria(RegistroHistoria, RegistroClinico);
            }
            else if (RegistroClinico.Controller.ToUpper().Equals("TRABAJOSOCIAL"))
            {
                html = getTrabajoSocial(RegistroHistoria, RegistroClinico);
            }
            else if (RegistroClinico.Controller.ToUpper().Equals("SEGUIMIENTOSALUDMENTAL"))
            {
                html = getSeguimientoSaludMental(RegistroHistoria, RegistroClinico);
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
            HTML += "</tr>";
            HTML += "</table>";
            HTML += firmaReporte(RegistroHistoria.ProfesionalId);
            return HTML;
        }
        public string getPsicologia(Entities.Historia.RegistroHistoria RegistroHistoria, Entities.Administracion.RegistroClinico RegistroClinico)
        {

            var Psicologia = JsonConvert.DeserializeObject<Psicologia>(RegistroHistoria.Contenido);

            String HTML = "";

            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableContent {valign:top; vertical-align:top; text-align:justify;border-collapse: collapse; font-family:Arial;} b {font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;} .tableContent.th, .tableContent td {padding: 10px; vertical-align:top; text-align:justify;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style>";
            HTML += cabeceraReporte(RegistroClinico.Descripcion.ToUpper());
            HTML += cabeceraPaciente(RegistroHistoria.PacienteId);
            //DATOS DEL REPORTE
            HTML += "<br/>";
            HTML += "<center><table  width='900px' class='tableContent' > ";
            HTML += "<tr>";
            HTML += "<td><b>Fecha: </b> "+ Psicologia.Fecha + " - " + Psicologia.Hora + "</td>";
            HTML += "</tr>";
            HTML += "</table><br/>";

            HTML += "<center><b>DATOS PERSONALES </b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr>";
            HTML += "<td ><b>Orientación Sexual:</b></td>";
            HTML += "<td>" + Psicologia.OrientacionSexual + "</td>";
            HTML += "<td ><b>¿Cuál?:</b></td>";
            HTML += "<td>" + Psicologia.OrientacionSexualCual + "</td>";
            HTML += "<td ><b>Nivel Educativo:</b></td>";
            HTML += "<td>" + Psicologia.NivelEducativo + "</td>";
            HTML += "<td colspan='2'><b>¿Otro - Cuál?:</b></td>" + Psicologia.NivelEducativoCual + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Nivel Socioeconómico:</b></td>";
            HTML += "<td>" + Psicologia.NivelSocioeconomico + "</td>";
            HTML += "<td  colspan='2'><b>Estado Civil</b></td>";
            HTML += "<td >" + Psicologia.EstadoCivil + "</td>";
            HTML += "<td colspan='2'><b>Religión:</b></td>";
            HTML += "<td>" + Psicologia.Religion + "</td>";           
            HTML += "</tr>";
            HTML += "</table> <br/>";

            HTML += "<center><b>EVOLUCIÓN DE LA HISTORIA</b> </center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr>";
            HTML += "<td ><b>Motivo de Consulta:</b></td>";
            HTML += "<td>" + Psicologia.MotivoConsulta + "</td>";          
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Factor Desencadenante:</b></td>";
            HTML += "<td>" + Psicologia.FactorDesencadenante + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Área Escolar:</b></td>";
            HTML += "<td>" + Psicologia.AreaEscolar + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Área Pareja:</b></td>";
            HTML += "<td>" + Psicologia.AreaPareja + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Área Laboral:</b></td>";
            HTML += "<td>" + Psicologia.AreaLaboral + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Área Familiar:</b></td>";
            HTML += "<td>" + Psicologia.AreaFamiliar + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Área Sexual:</b></td>";
            HTML += "<td>" + Psicologia.AreaSexual + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Área Social:</b></td>";
            HTML += "<td>" + Psicologia.AreaSocial + "</td>";
            HTML += "</tr>";
            HTML += "</table> <br/>";

            HTML += "<center><b>TAMIZAJE DE VIOLENCIA</b> </center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr>";
            HTML += "<td  colspan='2'><b>¿Usted ha sido víctima de violencia y/o maltrato?: </b>" + Psicologia.VictimaViolencia + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='2'><b>¿Alguna vez ha sido golpeada-o por su pareja?: </b>" + Psicologia.Golpeada + "</td>";            
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='2'><center><b>TIPO DE VIOLENCIA</b><c/enter></td>";          
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Violencia Física:</b> " + Psicologia.ViolenciaFisica + "</td>";
            HTML += "<td ><b>Violencia Psicológica:</b> " + Psicologia.ViolenciaPsicologica + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Violencia Sexual:</b> " + Psicologia.ViolenciaSexual + "</td>";
            HTML += "<td ><b>Violencia Económica:</b> " + Psicologia.ViolenciaEconomica + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Violencia Patrimonial:</b> " + Psicologia.ViolenciaPatrimonial + "</td>";
            HTML += "<td ><b>Negligencia y/o Abandono:</b> " + Psicologia.Negligencia + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Abuso Sexual:</b> " + Psicologia.AbusoSexual + "</td>";
            HTML += "<td ><b>Acoso Sexual:</b> " + Psicologia.AcosoSexual + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='2'><b>Asalto Sexual:</b> " + Psicologia.AsaltoSexual + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='2'><b>Otro tipo de violencia:</b> " + Psicologia.OtroTipoViolencia + "</td>";            
            HTML += "</tr>";

            HTML += "<tr>";
            HTML += "<td colspan='2'><center><b>ANTECEDENTES PASADO DE MALTRATO O/ VIOLENCIA</b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Denuncia o reporte sector justicia:</b> " + Psicologia.DenunciaMaltrato + "</td>";
            HTML += "<td ><b>Fecha:</b> " + Psicologia.FechaMaltrato + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='2'><b>Ciudad:</b> " + Psicologia.CiudadMaltrato + "</td>";
            HTML += "</tr>";           
            HTML += "</table> <br/>";
            //Anamnesis
            HTML += "<center><b>ANAMNESIS</b> </center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr>";
            HTML += "<td><b>Anamnesis:</b></td>";
            HTML += "<td colspan='4'>" + Psicologia.Anamnesis + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Antecedentes Patológicos:</b></td>";
            HTML += "<td  colspan='4'>" + Psicologia.AntecedentesPatologicos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>ANTECEDENTES DE CONSUMO </b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='3'><b>Spa (sustancias psicoactivas):</b> " + Psicologia.Spa + "</td>";
            HTML += "<td ><b>Alcohol:</b> " + Psicologia.Alcohol + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b>Cigarrillo:</b> " + Psicologia.Cigarrillo + "</td>";
            HTML += "<td  colspan='3'><b>Otro:</b> " + Psicologia.CualConsumo + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>CONDUCTA SUICIDA </b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><bHistoria pasada de intento y/o hospitalización:</b></td>";
            HTML += "<td  colspan='4'>" + Psicologia.HistoriaConductaSuicida + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Riesgo presente:</b> " + Psicologia.RiesgoPresenteConductaSuicida + "</td>";
            HTML += "<td ><b>Remisión:</b> " + Psicologia.RemisionConductaSuicida + "</td>";
            HTML += "<td ><b>Red de Apoyo:</b> " + Psicologia.RedApoyoConductaSuicida + "</td>";
            HTML += "<td ><b>Personas cercanas o historias de suicidio:</b> " + Psicologia.PersonasCercanasConductaSuicida + "</td>";
            HTML += "</tr>";
            HTML += "</table> <br/>";


            //Anamnesis
            HTML += "<center><b>EXAMEN MENTAL</b> </center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr>";
            HTML += "<td><b>Apariencia, porte y actitud:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.AparienciaExamenMental + "</td>";
            HTML += "</tr>";        
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>CONDUCTA MOTORA </b><c/enter></td>";
            HTML += "</tr>";            
            HTML += "<tr>";
            HTML += "<td ><b>Agitación:</b> " + Psicologia.AgitacionExamenMental + "</td>";
            HTML += "<td ><b>Lentitud:</b> " + Psicologia.LentitudExamenMental + "</td>";
            HTML += "<td ><b>Inhibición:</b> " + Psicologia.InhibicionExamenMental + "</td>";
            HTML += "<td ><b>Otra:</b> " + Psicologia.CualExamenMental + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='2'><b>Atención:</b> " + Psicologia.AtencionExamenMental + "</td>";
            HTML += "<td colspan='2'><b>Conciencia:</b> " + Psicologia.ConcienciaExamenMental + "</td>";           
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>ORIENTACIÓN </b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td  colspan='4'><b>Tiempo:</b> " + Psicologia.TiempoOrientacion + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td  colspan='4'><b>Lugar:</b> " + Psicologia.LugarOrientacion + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td  colspan='4'><b>Persona:</b> " + Psicologia.PersonaOrientacion + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>LENGUAJE</b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td ><b>Velocidad:</b> " + Psicologia.VelocidadLenguaje + "</td>";
            HTML += "<td ><b>Tono de voz:</b> " + Psicologia.CursoLenguaje + "</td>";
            HTML += "<td ><b>Curso:</b> " + Psicologia.TonoVozLenguaje + "</td>";
            HTML += "<td ><b>Calidad:</b> " + Psicologia.CalidadLenguaje + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>MEMORIA</b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Descripción Memoria:</b> " + Psicologia.DescripcionMemoria + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>JUICIO Y RACIOCINIO</b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>DescripciCONDUCTASUICIDAón Juicio Y Raciocinio:</b> " + Psicologia.DescripcionJuicioRaciocinio + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Pensamiento:</b> " + Psicologia.Pensamiento + "</td>";
            HTML += "</tr>";
            HTML += "<td colspan='4'><center><b>ESTADO AFECTIVO</b><c/enter></td>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Estado Animo:</b> " + Psicologia.EstadoAnimo + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Impresión diagnostica de inteligencia:</b> " + Psicologia.ImpresionDiagnosticaInteligencia + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4'><center><b>HÁBITOS </b><c/enter></td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Sueño:</b> " + Psicologia.SueñoHabitos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Alimentación:</b> " + Psicologia.AlimentacionHabitos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Introspección:</b> " + Psicologia.InstrospeccionHabitos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td colspan='4' ><b>Prospección:</b> " + Psicologia.ProspeccionHabitos + "</td>";
            HTML += "</tr>";
            HTML += "</table> <br/>";
            //Evaluación de Riesgo
            HTML += "<center><b>EVALUACIÓN DE RIESGO</b> </center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr>";
            HTML += "<td><b>Evaluación de Riesgo:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.EvaluacionRiesgo + "</td>";
            HTML += "</tr>";
            HTML += "</table> <br/>";
            //Intervención Programada
            HTML += "<center><b>INTERVENCIÓN PROGRAMADA</b> </center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr>";
            HTML += "<td><b>Primeros auxilios psicológicos:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.PrimerosAuxiliosPsicologicos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b>Remisión para tratamiento:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.PrimerosAuxiliosPsicologicos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b>Plan de intervención:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.PrimerosAuxiliosPsicologicos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b>Remisión intersectorial:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.PrimerosAuxiliosPsicologicos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b>Seguimiento y evolución:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.PrimerosAuxiliosPsicologicos + "</td>";
            HTML += "</tr>";
            HTML += "<tr>";
            HTML += "<td><b>Información y educación:</b></td>";
            HTML += "<td colspan='3'>" + Psicologia.PrimerosAuxiliosPsicologicos + "</td>";
            HTML += "</tr>"; HTML += "</table> <br/>";
            HTML += firmaReporte(RegistroHistoria.ProfesionalId);
            return HTML;
        }

        public string getTerapiaOcupacional(Entities.Historia.RegistroHistoria RegistroHistoria, Entities.Administracion.RegistroClinico RegistroClinico)
        {

            var TerapiaOcupacional = JsonConvert.DeserializeObject<TerapiaOcupacional>(RegistroHistoria.Contenido);

            String HTML = "";

            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableContent {valign:top; vertical-align:top; text-align:justify;border-collapse: collapse; font-family:Arial;} b {font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;} .tableContent.th, .tableContent td {padding: 10px; vertical-align:top; text-align:justify;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style>";
            HTML += cabeceraReporte(RegistroClinico.Descripcion.ToUpper());
            HTML += cabeceraPaciente(RegistroHistoria.PacienteId);
            //DATOS DEL REPORTE
            HTML += "<br/>";
            HTML += "<center><table  width='900px' class='tableContent' > ";
            HTML += "<tr>";
            HTML += "<td><b>Fecha: </b> " + TerapiaOcupacional.Fecha + " - " + TerapiaOcupacional.Hora + "</td>";
            HTML += "</tr>";
            HTML += "</table><br/>";

            HTML += "<center><b></b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><b>Calidad de la información:</b>" + TerapiaOcupacional.CalidadInformacion + "</td></tr>";
            HTML += "<tr><td ><b>Hijos:</b>" + TerapiaOcupacional.Hijos + "</td></tr>";
            HTML += "<tr><td ><b>Motivo de Consulta:</b>" + TerapiaOcupacional.MotivoConsulta + "</td></tr>";
            HTML += "<tr><td ><b>Entornos de Riesgo:</b>" + TerapiaOcupacional.EntornosRiesgo + "</td></tr>";
            ///pendiente tabla consumo
            HTML += "<tr><td ><b>Personalidad Previa:</b>" + TerapiaOcupacional.PersonalidadPrevia + "</td></tr>";
            HTML += "</table><br/>";

            HTML += "<center><b>Antecededentes</b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><b>Patológicos:</b>" + TerapiaOcupacional.PatologicosAntecedentes + "</td></tr>";
            HTML += "<tr><td ><b>Farmacológicos:</b>" + TerapiaOcupacional.FarmacologicosAntecedentes + "</td></tr>";
            HTML += "<tr><td ><b>Quirúrgicos:</b>" + TerapiaOcupacional.QuirurgicosAntecedentes + "</td></tr>";
            HTML += "<tr><td ><b>Traumáticos:</b>" + TerapiaOcupacional.TraumaticosAntecedentes + "</td></tr>";
            HTML += "<tr><td ><b>Alérgicos:</b>" + TerapiaOcupacional.AlergicosAntecedentes + "</td></tr>";
            HTML += "<tr><td ><b>Familiares:</b>" + TerapiaOcupacional.FamiliaresAntecedentes + "</td></tr>";            
            HTML += "</table><br/>";

            //Componentes de Ejecución
            HTML += "<center><b>COMPONENTES DE EJECUCIÓN</ b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><center><b>CONTROL MOTOR</b></center></td></tr>";
            HTML += "<tr><td ><b>Movimientos Voluntarios (Corticales):</b>" + TerapiaOcupacional.MovimientosVoluntarios + "</td></tr>";
            HTML += "<tr><td ><b>Movimientos Automáticos (Subcorticales):</b>" + TerapiaOcupacional.MovimientosAutomaticos + "</td></tr>";
            HTML += "<tr><td ><b>Movimientos Reflejos (Medular):</b>" + TerapiaOcupacional.MovimientosReflejos + "</td></tr>";
            HTML += "<tr><td ><center><b>EQUILIBRIO</b></center></td></tr>";
            HTML += "<tr><td ><b>Dinámico:</b>" + TerapiaOcupacional.Dinamico + "</td></tr>";
            HTML += "<tr><td ><b>Estático:</b>" + TerapiaOcupacional.Estatico + "</td></tr>";
            HTML += "<tr><td ><center><b>COORDINACIÓN MOTOR GRUESA</b></center></td></tr>";
            HTML += "<tr><td ><b>Control de Cabeza:</b>" + TerapiaOcupacional.ControlCabeza + "</td></tr>";
            HTML += "<tr><td ><b>Control de Tronco:</b>" + TerapiaOcupacional.ControlTronco + "</td></tr>";
            HTML += "<tr><td ><b>Control de M.M.I.I.:</b>" + TerapiaOcupacional.ControlMMII + "</td></tr>";
            HTML += "<tr><td ><b>Control de M.M.S.S.:</b>" + TerapiaOcupacional.ControldeMMSS + "</td></tr>";
            HTML += "<tr><td ><center><b>COORDINACIÓN MOTOR FINA</b></center></td></tr>";
            HTML += "<tr><td ><b>Precisión:</b>" + TerapiaOcupacional.Precision + "</td></tr>";
            HTML += "<tr><td ><b>Control de la Fuerza:</b>" + TerapiaOcupacional.ControlFuerza + "</td></tr>";
            HTML += "<tr><td ><b>Manejo Espacial:</b>" + TerapiaOcupacional.ManejoEspacial + "</td></tr>";
            HTML += "<tr><td ><center><b>PATRONES FUNCIONALES</b></center></td></tr>";
            HTML += "<tr><td ><b>Mano - Cabeza:</b>" + TerapiaOcupacional.ManoCabeza + "</td></tr>";
            HTML += "<tr><td ><b>Mano - Boca:</b>" + TerapiaOcupacional.ManoBoca + "</td></tr>";
            HTML += "<tr><td ><b>Mano - Rodilla:</b>" + TerapiaOcupacional.ManoRodilla + "</td></tr>";
            HTML += "<tr><td ><b>Mano - Pie:</b>" + TerapiaOcupacional.ManoPie + "</td></tr>";
            HTML += "<tr><td ><center><b>PATRONES GLOBALES</b></center></td></tr>";
            HTML += "<tr><td ><b>Marcha:</b>" + TerapiaOcupacional.Marcha + "</td></tr>";
            HTML += "<tr><td ><b>Correr:</b>" + TerapiaOcupacional.Correr + "</td></tr>";
            HTML += "<tr><td ><b>Saltar:</b>" + TerapiaOcupacional.Saltar + "</td></tr>";
            HTML += "<tr><td ><b>Patear:</b>" + TerapiaOcupacional.Patear + "</td></tr>";
            HTML += "<tr><td ><b>Empujar:</b>" + TerapiaOcupacional.Empujar + "</td></tr>";
            HTML += "<tr><td ><b>Halar:</b>" + TerapiaOcupacional.Halar + "</td></tr>";
            HTML += "<tr><td ><b>Sujetar:</b>" + TerapiaOcupacional.Sujetar + "</td></tr>";
            HTML += "<tr><td ><b>Lanzar:</b>" + TerapiaOcupacional.Lanzar + "</td></tr>";
            HTML += "<tr><td ><center><b>PATRONES INTEGRALES</b></center></td></tr>";
            HTML += "<tr><td ><b>Prensión Digital:</b>" + TerapiaOcupacional.PrensionDigital + "</td></tr>";
            HTML += "<tr><td ><b>Prensión Palmar:</b>" + TerapiaOcupacional.PrensionPalmar + "</td></tr>";
            HTML += "<tr><td ><center><b>COMPONENTE SENSORIAL</b></center></td></tr>";
            HTML += "<tr><td ><b>Táctil:</b>" + TerapiaOcupacional.Tactil + "</td></tr>";
            HTML += "<tr><td ><b>Propioceptivo:</b>" + TerapiaOcupacional.Propioceptivo + "</td></tr>";
            HTML += "<tr><td ><b>Auditivo:</b>" + TerapiaOcupacional.Auditivo + "</td></tr>";
            HTML += "<tr><td ><b>Vestibular:</b>" + TerapiaOcupacional.Vestibular + "</td></tr>";
            HTML += "<tr><td ><b>Gustativo:</b>" + TerapiaOcupacional.Gustativo + "</td></tr>";
            HTML += "<tr><td ><b>Olfatorio:</b>" + TerapiaOcupacional.Olfatorio + "</td></tr>";
            HTML += "<tr><td ><b>Visual:</b>" + TerapiaOcupacional.Visual + "</td></tr>";
            HTML += "<tr><td ><center><b>COMPONENTE COGNITIVO</b></center></td></tr>";
            HTML += "<tr><td ><b>Atención:</b>" + TerapiaOcupacional.Atencion + "</td></tr>";
            HTML += "<tr><td ><b>Memoria:</b>" + TerapiaOcupacional.Memoria + "</td></tr>";
            HTML += "<tr><td ><b>Orientación:</b>" + TerapiaOcupacional.Orientacion + "</td></tr>";
            HTML += "<tr><td ><b>Seguimiento de instrucciones:</b>" + TerapiaOcupacional.SeguimientoInstrucciones + "</td></tr>";
            HTML += "<tr><td ><b>Inicia, desarrolla y culmina una actividad:</b>" + TerapiaOcupacional.IniciaDesarrollaCulmina + "</td></tr>";
            HTML += "<tr><td ><b>Resolución de problemas:</b>" + TerapiaOcupacional.ResolucionProblemas + "</td></tr>";
            HTML += "<tr><td ><center><b>COMPONENTE PSICOSOCIAL</b></center></td></tr>";
            HTML += "<tr><td ><b>Contacto visual:</b>" + TerapiaOcupacional.ContactoVisual + "</td></tr>";
            HTML += "<tr><td ><b>Forma de comunicación:</b>" + TerapiaOcupacional.FormaComunicacion + "</td></tr>";
            HTML += "<tr><td ><b>Autocontrol:</b>" + TerapiaOcupacional.Autocontrol + "</td></tr>";
            HTML += "<tr><td ><b>Manejo de límites y normas:</b>" + TerapiaOcupacional.ManejoLimites + "</td></tr>";
            HTML += "<tr><td ><b>Adaptación a contextos nuevos:</b>" + TerapiaOcupacional.AdaptacionContextosNuevos + "</td></tr>";
            HTML += "<tr><td ><b>Valores e intereses:</b>" + TerapiaOcupacional.ValoresIntereses + "</td></tr>";
            HTML += "<tr><td ><b>AutoConcepto:</b>" + TerapiaOcupacional.AutoConcepto + "</td></tr>";
            HTML += "<tr><td ><b>Conducta social:</b>" + TerapiaOcupacional.ConductaSocial + "</td></tr>";
            HTML += "</table><br/>";
            //Áreas de Ejecución
            HTML += "<center><b>ÁREAS DE EJECUCIÓN</ b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><center><b>ACTIVIDADES DE LA VIDA DIARIA BÁSICAS</b></center></td></tr>";
            HTML += "<tr><td ><b>Orinar y defecar:</b>" + TerapiaOcupacional.OrinarDefecar + "</td></tr>";
            HTML += "<tr><td ><b>Vestido:</b>" + TerapiaOcupacional.Vestido + "</td></tr>";
            HTML += "<tr><td ><b>Alimentación:</b>" + TerapiaOcupacional.Alimentacion + "</td></tr>";
            HTML += "<tr><td ><b>Mantenimiento de la salud:</b>" + TerapiaOcupacional.MantenimientoSalud + "</td></tr>";
            HTML += "<tr><td ><b>Cuidado de enseres personales:</b>" + TerapiaOcupacional.CuidadoEnseresPersonales + "</td></tr>";
            HTML += "<tr><td ><b>Rutina medicamentosa:</b>" + TerapiaOcupacional.RutinaMedicamentosa + "</td></tr>";
            HTML += "<tr><td ><b>Movilidad Funcional:</b>" + TerapiaOcupacional.MovilidadFuncional + "</td></tr>";
            HTML += "<tr><td ><center><b>ACTIVIDADES DE LA VIDA INSTRUMENTALES</b></center></td></tr>";
            HTML += "<tr><td ><b>Escolaridad (Último año cursado):</b>" + TerapiaOcupacional.Escolaridad + "</td></tr>";
            HTML += "<tr><td ><b>Empleo:</b>" + TerapiaOcupacional.Empleo + "</td></tr>";
            HTML += "<tr><td ><b>Trabajo voluntario:</b>" + TerapiaOcupacional.TrabajoVoluntario + "</td></tr>";
            HTML += "<tr><td ><b>Organización del hogar:</b>" + TerapiaOcupacional.OrganizacionHogar + "</td></tr>";
            HTML += "<tr><td ><b>Cuidado de otros:</b>" + TerapiaOcupacional.CuidadoOtros + "</td></tr>";
            HTML += "</table><br/>";
            //Plan de Tratamiento
            HTML += "<center><b>PLAN DE TRATAMIENTO</ b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";         
            HTML += "<tr><td ><b>Meta:</b>" + TerapiaOcupacional.Meta + "</td></tr>";
            HTML += "<tr><td ><b>Objetivo General:</b>" + TerapiaOcupacional.ObjetivoGeneral + "</td></tr>";
            HTML += "<tr><td ><b>Objetivos Especificos:</b>" + TerapiaOcupacional.ObjetivosEspecificos + "</td></tr>";
            HTML += "</table> <br/>";            
            HTML += firmaReporte(RegistroHistoria.ProfesionalId);
            return HTML;
        }
        public string getPsiquiatria(Entities.Historia.RegistroHistoria RegistroHistoria, Entities.Administracion.RegistroClinico RegistroClinico)
        {

            var Psiquiatria = JsonConvert.DeserializeObject<Psiquiatria>(RegistroHistoria.Contenido);

            String HTML = "";

            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableContent {valign:top; vertical-align:top; text-align:justify;border-collapse: collapse; font-family:Arial;} b {font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;} .tableContent.th, .tableContent td {padding: 10px; vertical-align:top; text-align:justify;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style>";
            HTML += cabeceraReporte(RegistroClinico.Descripcion.ToUpper());
            HTML += cabeceraPaciente(RegistroHistoria.PacienteId);
            //DATOS DEL REPORTE
            HTML += "<br/>";
            HTML += "<center><table  width='900px' class='tableContent' > ";
            HTML += "<tr>";
            HTML += "<td><b>Fecha: </b> " + Psiquiatria.Fecha + " - " + Psiquiatria.Hora + "</td>";
            HTML += "</tr>";
            HTML += "</table><br/>";

            HTML += "<center><b></b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><b>Motivo de Consulta:</b>" + Psiquiatria.MotivoConsulta + "</td></tr>";
            HTML += "<tr><td ><b>Enfermedad Actual:</b>" + Psiquiatria.EnfermedadActual + "</td></tr>";
            HTML += "<tr><td ><b>Antecedentes Personales:</b>" + Psiquiatria.AntecedentesPersonales + "</td></tr>";
            HTML += "<tr><td ><b>Antecedentes Familiares:</b>" + Psiquiatria.AntecedentesFamiliares + "</td></tr>";
            ///pendiente tabla consumo
            HTML += "<tr><td ><b>Patrón de Consumo:</b>" + Psiquiatria.PatronConsumo + "</td></tr>";
            HTML += "<tr><td ><b>Examen Físico:</b>" + Psiquiatria.ExamenFisico + "</td></tr>";
            HTML += "<tr><td ><b>Examen Mental:</b>" + Psiquiatria.ExamenMental + "</td></tr>";
            HTML += "<tr><td ><b>Paraclínicos:</b>" + Psiquiatria.Paraclinicos + "</td></tr>";
            HTML += "<tr><td ><b>Prescripción de Tratamiento:</b>" + Psiquiatria.PrescripcionTratamiento + "</td></tr>";
            HTML += "<tr><td ><b>Evolución y Pertinencia:</b>" + Psiquiatria.EvolucionPertinencia + "</td></tr>";
            HTML += "</table><br/>";

          

           
            HTML += firmaReporte(RegistroHistoria.ProfesionalId);
            return HTML;
        }

        public string getTrabajoSocial(Entities.Historia.RegistroHistoria RegistroHistoria, Entities.Administracion.RegistroClinico RegistroClinico)
        {

            var TrabajoSocial = JsonConvert.DeserializeObject<TrabajoSocial>(RegistroHistoria.Contenido);

            String HTML = "";

            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableContent {valign:top; vertical-align:top; text-align:justify;border-collapse: collapse; font-family:Arial;} b {font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;} .tableContent.th, .tableContent td {padding: 10px; vertical-align:top; text-align:justify;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style>";
            HTML += cabeceraReporte(RegistroClinico.Descripcion.ToUpper());
            HTML += cabeceraPaciente(RegistroHistoria.PacienteId);
            //DATOS DEL REPORTE
            HTML += "<br/>";
            HTML += "<center><table  width='900px' class='tableContent' > ";
            HTML += "<tr>";
            HTML += "<td><b>Fecha: </b> " + TrabajoSocial.Fecha + " - " + TrabajoSocial.Hora + "</td>";
            HTML += "</tr>";
            HTML += "</table><br/>";

            HTML += "<center><b>Áreas</b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><b>Área Personal (Hobbies-Amigos(as), redes Sociales.):</b>" + TrabajoSocial.AreaPersonal + "</td></tr>";
            HTML += "<tr><td ><b>Área Familiar:</b>" + TrabajoSocial.AreaFamiliar + "</td></tr>";
            HTML += "<tr><td ><b>Área Sexual:</b>" + TrabajoSocial.AreaSexual + "</td></tr>";
            HTML += "<tr><td ><b>Área Laboral:</b>" + TrabajoSocial.AreaLaboral + "</td></tr>";
            HTML += "<tr><td ><b>Área Pareja:</b>" + TrabajoSocial.AreaPareja + "</td></tr>";
            HTML += "</table><br/>";

            HTML += "<center><b>Psicoeducación</b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";            
            HTML += "<tr><td ><b>Información Psicoeducación:</b>" + TrabajoSocial.InformacionPsicoeducacion + "</td></tr>";
            HTML += "<tr><td ><b>Cumplimiento deberes:</b>" + TrabajoSocial.CumplimientoDeberes + "</td></tr>";
            HTML += "</table><br/>";

            HTML += "<center><b>Antecedentes (Revisión de soportes)</b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><b>Antecedentes Médicos:</b>" + TrabajoSocial.AntecedentesMedicos + "</td></tr>";
            HTML += "<tr><td ><b>Antecedentes Psicofisicos:</b>" + TrabajoSocial.AntecedentesPsicofisicos + "</td></tr>";
            HTML += "<tr><td ><b>Antecedentes Legales:</b>" + TrabajoSocial.AntecedentesLegales + "</td></tr>";
            HTML += "<tr><td ><b>Antecedentes Patologicos:</b>" + TrabajoSocial.AntecedentesPatologicos + "</td></tr>";
            HTML += "</table><br/>";

            HTML += "<center><b>Zonas Vulnerables</b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";

            HTML += "<tr><td ><b>Principales problemas comunidad:</b>" + TrabajoSocial.PrincipalesProblemasComunidad + "</td></tr>";
            HTML += "<tr><td ><b>Existencia de organizaciones comunitarias:</b>" + TrabajoSocial.ExistenciaOrganizacionesCcomunitarias + "</td></tr>";
            HTML += "<tr><td ><b>Existencia de establecimientos educativos:</b>" + TrabajoSocial.ExistenciaestablecimientosEducativos + "</td></tr>";
            HTML += "<tr><td ><b>Principales instituciones presentes:</b>" + TrabajoSocial.PrincipalesLideresReconocidos + "</td></tr>";
            HTML += "<tr><td ><b>Evaluación del Riesgo:</b>" + TrabajoSocial.EvaluacionRiesgo + "</td></tr>";
            HTML += "<tr><td ><b>Conclusiones:</b>" + TrabajoSocial.Conclusiones + "</td></tr>";
            HTML += "<tr><td ><b>Medidas a Tomar:</b>" + TrabajoSocial.MedidasTomar + "</td></tr>";
            HTML += "<tr><td ><b>Remisión:</b>" + TrabajoSocial.Remision + "</td></tr>";
            HTML += "</table><br/>";
            
            HTML += firmaReporte(RegistroHistoria.ProfesionalId);
            return HTML;
        }

        public string getSeguimientoSaludMental(Entities.Historia.RegistroHistoria RegistroHistoria, Entities.Administracion.RegistroClinico RegistroClinico)
        {

            var SeguimientoSaludMental = JsonConvert.DeserializeObject<SeguimientoSaludMental>(RegistroHistoria.Contenido);

            String HTML = "";

            HTML = "<meta http-equiv='Content-Type' content='text/html; charset=UTF-8' /><style>.tableContent {valign:top; vertical-align:top; text-align:justify;border-collapse: collapse; font-family:Arial;} b {font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;} .tableContent.th, .tableContent td {padding: 10px; vertical-align:top; text-align:justify;font-family: Arial, 'Helvetica Neue', Helvetica, sans-serif;}</style>";
            HTML += cabeceraReporte(RegistroClinico.Descripcion.ToUpper());
            HTML += cabeceraPaciente(RegistroHistoria.PacienteId);
            //DATOS DEL REPORTE
            HTML += "<br/>";
            HTML += "<center><table  width='900px' class='tableContent' > ";
            HTML += "<tr>";
            HTML += "<td><b>Fecha: </b> " + SeguimientoSaludMental.Fecha + " - " + SeguimientoSaludMental.Hora + "</td>";
            HTML += "</tr>";
            HTML += "</table><br/>";

            HTML += "<center><b></b></center>";
            HTML += "<center><table  width='900px' class='tableContent' border='1'> ";
            HTML += "<tr><td ><b>Autoevaluación:</b>" + SeguimientoSaludMental.Autoevaluacion + "</td></tr>";
            HTML += "<tr><td ><b>Nivel de Permanencia:</b>" + SeguimientoSaludMental.NivelPermanencia + "</td></tr>";
            HTML += "<tr><td ><b>Nivel de Convivencia:</b>" + SeguimientoSaludMental.NivelConvivencia + "</td></tr>";
            HTML += "<tr><td ><b>Sexualidad:</b>" + SeguimientoSaludMental.Sexualidad + "</td></tr>";
            HTML += "<tr><td ><b>Objetivo de la Sesión:</b>" + SeguimientoSaludMental.ObjetivoSesion + "</td></tr>";
            HTML += "<tr><td ><b>Evolución:</b>" + SeguimientoSaludMental.Evolucion + "</td></tr>";
            HTML += "<tr><td ><b>Plan de Manejo:</b>" + SeguimientoSaludMental.PlanManejo + "</td></tr>";
            HTML += "</table><br/>";




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
            
            var firma = db.ProfesionalFirma.Where(x => x.ProfesionalId == _ProfesionalId).FirstOrDefault();
            

            String HTML = "<br/><br/><br/>";
            HTML += "<table  width='900px'  class='tableDetalle'>";
            HTML += "<tr>";
            if (firma != null)
            {
                HTML += "<td><img style = 'display:block; height:100px;' id = 'base64image' src = 'data:image/png;base64," + firma.Firma64 + "' /></td>";
                
            }
            else
                HTML += "<td></td>";
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