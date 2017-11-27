using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Seguridad;

namespace AbcMedical.Controllers
{
    public class HistoryController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public ActionResult Index()
        {

            var user = (Usuario)System.Web.HttpContext.Current.Session["User"];
            if (user != null)
            {
                ViewBag.Username = user.Login;
                ViewBag.UserId = user.UsuarioId;
                var profesionalId = db.Profesionals.Where(x => x.UsuarioId == user.UsuarioId).FirstOrDefault();
                if (profesionalId == null)
                {
                    ViewBag.ProfesionalId = "1";
                }
                ViewBag.ProfesionalId = profesionalId.ProfesionalId;
                ViewBag.Title = "Home Page";
               
                return View();
                
            }
            else
                return RedirectToAction("Logoff", "Login");

            

            
        }
       
    }
}
