using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities.Seguridad
{
    [Table("Permisos")]
    public class Permiso
    {
        [Display(Name = "Id")]
        public int PermisoId { get; set; }

        public string Opcion { get; set; }
        public string Url { get; set; }
        public string ModuloAplicacion { get; set; }
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
    public class Opciones
    {
        public int PerfilId { get; set; }
        public Boolean PuestosAtencion { get; set; }
        public Boolean Profesionales { get; set; }
        public Boolean Especialidades { get; set; }
        public Boolean Diagnosticos { get; set; }
        public Boolean Pacientes { get; set; }
        public Boolean PacientesActivos { get; set; }
        public Boolean HistoriasCreadas { get; set; }

        public Boolean HistoriaClinica { get; set; }

        public Boolean Usuarios { get; set; }
        public Boolean Perfiles { get; set; }
        public Boolean MatrizSeguridad { get; set; }
        public Boolean Bitacora { get; set; }

        public Boolean CargarArchivoDigital { get; set; }
        public Boolean TipoAnexo { get; set; }
        public Boolean VolumenAlmacenamiento { get; set; }


    }
}
