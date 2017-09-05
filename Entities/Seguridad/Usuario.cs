using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Administracion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Seguridad
{
    [Table("Usuario")]
    public class Usuario
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int UsuarioId { get; set; }
        public int CompanyClientId { get; set; }
        public virtual CompanyClient CompanyClient { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo de Identificación")]
        public int TipoIdentificacionId { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Nombres { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Apellidos { get; set; }
        public string FechaIngreso { get; set; }
        public Boolean Activo { get; set; }
        public Boolean Bloqueado { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
    }
}
