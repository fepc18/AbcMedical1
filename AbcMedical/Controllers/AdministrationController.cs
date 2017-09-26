using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbcMedical.Controllers
{
    public class AdministrationController : Controller
    {
        public ActionResult Index()
        {
            var user = (Usuario)System.Web.HttpContext.Current.Session["User"];
            ViewBag.Username = user.Login;
            ViewBag.Title = "Home Page";

            return View();
        }
       
    }
}
