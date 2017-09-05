using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Seguridad;
namespace AbcMedical.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult Login(Login login)
        {

            return RedirectToAction("Index", "Home",login);

            //return View();
        }
    }
}
