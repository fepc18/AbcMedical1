using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Seguridad;
namespace AbcMedical.Controllers
{
    public class AdministrationController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public ActionResult Index()
        {
            var user = (Usuario)System.Web.HttpContext.Current.Session["User"];
            ViewBag.Username = user.Login;
            ViewBag.Title = "Home Page";
            var perfilId = user.PerfilId;
            Opciones opciones = new Opciones();
            opciones.PuestosAtencion = estaOpcion(perfilId, "PuestosAtencion");
            opciones.Profesionales = estaOpcion(perfilId, "Profesionales");
            opciones.Especialidades = estaOpcion(perfilId, "Especialidades");
            opciones.Diagnosticos = estaOpcion(perfilId, "Diagnosticos");
            opciones.Pacientes = estaOpcion(perfilId, "Pacientes");
            opciones.PacientesActivos = estaOpcion(perfilId, "PacientesActivos");
            opciones.HistoriasCreadas = estaOpcion(perfilId, "HistoriasCreadas");

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
