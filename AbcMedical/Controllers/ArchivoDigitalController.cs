using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Entities.Seguridad;
namespace AbcMedical.Controllers
{
    public class ArchivoDigitalController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public ActionResult Index()
        {
            var user = (Usuario)System.Web.HttpContext.Current.Session["User"];
            ViewBag.Username = user.Login;
            ViewBag.Title = "Home Page";
            var perfilId = user.PerfilId;
            Opciones opciones = new Opciones();
            opciones.CargarArchivoDigital = estaOpcion(perfilId, "CargarArchivoDigital");
            opciones.TipoAnexo = estaOpcion(perfilId, "TipoAnexo");
            opciones.VolumenAlmacenamiento = estaOpcion(perfilId, "VolumenAlmacenamiento");
            
            return View(opciones);
            
        }
        public Boolean estaOpcion(int _perfilId, string _opcion)
        {
            Boolean resultado = false;
            var opcion = db.Permiso.Where(x => x.Opcion == _opcion).Where(x => x.PerfilId == _perfilId).FirstOrDefault();
            if (opcion != null)
                resultado = true;
            return resultado;
        }


    }

}
