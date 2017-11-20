using System.Web.Mvc;
using Entities.Seguridad;
namespace AbcMedical.Controllers
{
    public class ArchivoDigitalController : Controller
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
