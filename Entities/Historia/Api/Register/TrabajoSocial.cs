using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Historia.Api.Register
{
    public class TrabajoSocial
    {
        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string AreaPersonal { get; set; }
        public string AreaFamiliar { get; set; }
        public string AreaSexual { get; set; }
        public string AreaLaboral { get; set; }
        public string AreaPareja { get; set; }
    //    public List<ComposicionFamiliar> ComposicionFamiliar { get; set; }
        public string TipoFamilia { get; set; }
        public string OtroTipoFamilia { get; set; }
        public string ProblematicaFamiliar { get; set; }
        public string OtrosProblematicaFamiliar { get; set; }

        public string InformacionPsicoeducacion { get; set; }
        public string CumplimientoDeberes { get; set; }
        public string AntecedentesMedicos { get; set; }
        public string AntecedentesPsicofisicos { get; set; }
        public string AntecedentesLegales { get; set; }
        public string AntecedentesPatologicos { get; set; }
        public string PrincipalesProblemasComunidad { get; set; }
        public string ExistenciaOrganizacionesCcomunitarias { get; set; }
        public string ExistenciaestablecimientosEducativos { get; set; }
        public string PrincipalesLideresReconocidos { get; set; }
        public string PrincipalesInstitucionesPresentes { get; set; }
    //    public List<TratamientosAnteriores> TratamientosAnteriores { get; set; }

        public string EvaluacionRiesgo { get; set; }
        public string Conclusiones { get; set; }
        public string MedidasTomar { get; set; }
        public string Remision { get; set; }
    }
    public class ComposicionFamiliar
    {
        public string Nombres { get; set; }
        public string Parentesco { get; set; }
        public string Edad { get; set; }
        public string EstadoCivil { get; set; }
        public string Ocupacion { get; set; }
        public string FuenteIngresos { get; set; }
    }

    public class TratamientosAnteriores
    {
        public string Año { get; set; }
        public string Institucion { get; set; }
        public string Tipo { get; set; }
        public string Duracion { get; set; }
        public string Tratamiento { get; set; }
        public string Permanencia { get; set; }
        public string MotivoEgreso { get; set; }
    }


}
