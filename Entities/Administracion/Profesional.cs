using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Seguridad;
namespace Entities.Administracion
{
    [Table("Profesional")]
    public class Profesional
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int ProfesionalId { get; set; }
        public int CompanyClientId { get; set; }
       
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Código")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo de Identificación")]
        public int TipoIdentificacionId { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        [Display(Name = "Teléfono Fijo")]
        public string TelefonoFijo { get; set; }
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Numero Registro/Tarjeta Profesional")]
        public string NumeroRegistro { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int EspecialidadId { get; set; }
        public virtual Especialidad Especialidad { get; set; }
        public Boolean Activo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
