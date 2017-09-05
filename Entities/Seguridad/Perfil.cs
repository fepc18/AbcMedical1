using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Administracion;
namespace Entities.Seguridad
{
    public class Perfil
    {
        public int PerfilId { get; set; }
        public int CompanyClientId { get; set; }
        public virtual CompanyClient CompanyClient { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
