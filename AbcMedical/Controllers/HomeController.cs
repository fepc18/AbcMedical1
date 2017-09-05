using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AbcMedical.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }
        public ActionResult goAdministration()
        {

            return RedirectToAction("Index", "Administration");
        }
        public ActionResult goSecurity()
        {

            return RedirectToAction("Index", "Security");
        }
    }
}
