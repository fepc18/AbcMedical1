using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Seguridad;

namespace AbcMedical.Controllers
{
    public class HomeController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public ActionResult Index(Login login)
        {
            //var usuario = db.Usuarios.Where(x => x.Login == login.Username).Where(x=>x.CompanyClientId==1).FirstOrDefault();
            // var profesional = db.Profesionals.Where(x => x.UsuarioId == usuario.UsuarioId).Where(x => x.CompanyClientId == 1).FirstOrDefault();
            var user = (Usuario)System.Web.HttpContext.Current.Session["User"];
            if (user != null)
            {
                ViewBag.Username = user.Login;
                ViewBag.Title = "Home Page";

                return View(login);
            }
            else
                return    RedirectToAction("Logoff", "Login");
            
        }
        public ActionResult goAdministration()
        {

            return RedirectToAction("Index", "Administration");
        }
        public ActionResult goSecurity()
        {

            return RedirectToAction("Index", "Security");
        }
        public ActionResult goHistory()
        {

            return RedirectToAction("Index", "History");
        }


        public ActionResult ChangePassword()
        {
            

            var  user =(Usuario)System.Web.HttpContext.Current.Session["User"];
            ViewBag.Username = user.Login;
            //var user = db.Usuarios.Where(x => x.Login == login.Username).Where(x=>x.CompanyClientId==1).FirstOrDefault();            

            var change = new ChangePassword();
            change.UsuarioId = user.UsuarioId;
            
            return View(change);
        }
    }
}
