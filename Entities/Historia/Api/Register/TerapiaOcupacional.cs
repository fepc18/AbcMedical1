using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Historia.Api.Register
{
    public class TerapiaOcupacional
    {
        public string CalidadInformacion { get; set; }
        public string Hijos { get; set; }
        public string MotivoConsulta { get; set; }
        public string EntornosRiesgo { get; set; }
        public List<TablaConsumo> TablaConsumo { get; set; }
        public string PersonalidadPrevia { get; set; }

        public string PatologicosAntecedentes { get; set; }
        public string FarmacologicosAntecedentes { get; set; }
        public string QuirurgicosAntecedentes { get; set; }
        public string TraumaticosAntecedentes { get; set; }
        public string AlergicosAntecedentes { get; set; }
        public string FamiliaresAntecedentes { get; set; }

        public string MovimientosVoluntarios { get; set; }
        public string MovimientosAutomaticos { get; set; }
        public string MovimientosReflejos { get; set; }
        public string Dinamico { get; set; }
        public string Estatico { get; set; }
        public string ControlCabeza { get; set; }
        public string ControlTronco { get; set; }
        public string ControlMMII { get; set; }
        public string ControldeMMSS { get; set; }

        public string Precision { get; set; }
        public string ControlFuerza { get; set; }
        public string ManejoEspacial { get; set; }
        public string ManoCabeza { get; set; }
        public string ManoBoca { get; set; }
        public string ManoRodilla { get; set; }
        public string ManoPie { get; set; }

        public string Marcha { get; set; }
        public string Correr { get; set; }
        public string Saltar { get; set; }
        public string Patear { get; set; }
        public string Empujar { get; set; }
        public string Halar { get; set; }
        public string Sujetar { get; set; }
        public string Lanzar { get; set; }



        public string PrensionDigital { get; set; }
        public string PrensionPalmar { get; set; }
        public string Tactil { get; set; }
        public string Propioceptivo { get; set; }
        public string Auditivo { get; set; }
        public string Vestibular { get; set; }
        public string Gustativo { get; set; }
        public string Olfatorio { get; set; }
        public string Visual { get; set; }

        public string Atencion { get; set; }
        public string Memoria { get; set; }
        public string Orientacion { get; set; }
        public string SeguimientoInstrucciones { get; set; }
        public string IniciaDesarrollaCulmina { get; set; }
        public string ResolucionProblemas { get; set; }


        public string ContactoVisual { get; set; }
        public string FormaComunicacion { get; set; }
        public string Autocontrol { get; set; }
        public string ManejoLimites { get; set; }
        public string AdaptacionContextosNuevos { get; set; }
        public string ValoresIntereses { get; set; }
        public string AutoConcepto { get; set; }
        public string ConductaSocial { get; set; }

        public string OrinarDefecar { get; set; }
        public string Vestido { get; set; }
        public string Alimentacion { get; set; }
        public string MantenimientoSalud { get; set; }
        public string CuidadoEnseresPersonales { get; set; }
        public string RutinaMedicamentosa { get; set; }
        public string MovilidadFuncional { get; set; }

        public string Escolaridad { get; set; }
        public string Empleo { get; set; }
        public string TrabajoVoluntario { get; set; }
        public string OrganizaciónHogar { get; set; }
        public string CuidadoOtros { get; set; }
        public string Meta { get; set; }
        public string ObjetivoGeneral { get; set; }
        public string ObjetivosEspecificos { get; set; }
    }
    public class TablaConsumo
    {
        public string Sustancia { get; set; }
        public string EdadInicio { get; set; }
        public string TiempoConsumo { get; set; }
    }
}
