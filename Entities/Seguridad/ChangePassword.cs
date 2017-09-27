using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Seguridad
{
    public class ChangePassword
    {
        public int UsuarioId { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Contraseña Antigua")]
        [DataType(DataType.Password)]
        public string ClaveAntigua { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Contraseña Nueva")]
        [DataType(DataType.Password)]
        public string ClaveNueva { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Confirmar Contraseña Nueva")]
        [DataType(DataType.Password)]
        public string ConfirmarClaveNueva { get; set; }
    }
}
