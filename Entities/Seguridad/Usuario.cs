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
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo Electrónico")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string CorreoElectronico { get; set; }
        public DateTime FechaIngreso { get; set; }
        public Boolean Activo { get; set; }
        public Boolean Bloqueado { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public int PerfilId { get; set; }
        public virtual Perfil Perfil { get; set; }
        public Boolean CambiarPassword { get; set; }
    }
}
