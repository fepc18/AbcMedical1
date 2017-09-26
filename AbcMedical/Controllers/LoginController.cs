using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Seguridad;
using System.Web.SessionState;
namespace AbcMedical.Controllers
{
    public class LoginController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }
        public ActionResult Logoff()
        {
            ViewBag.Title = "Home Page";
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            ViewBag.viewError = false;

            var userGeneral= db.Usuarios.Where(x => x.Login == login.Username | x.CorreoElectronico == login.Username).FirstOrDefault();
            if (userGeneral.Bloqueado)
            {
                ViewBag.viewError = true;
                ViewBag.message = "El usuario se encuentra BLOQUEADO, comuniquese con el administrador del sistema.";
            }
            else if (!userGeneral.Activo)
            {
                ViewBag.viewError = true;
                ViewBag.message = "El usuario se encuentra INACTIVO, comuniquese con el administrador del sistema.";
            }
            else {
                var usuario = db.Usuarios.Where(x => x.Login == login.Username | x.CorreoElectronico == login.Username)
                                .Where(x => x.Password == login.Password).FirstOrDefault();
                if (usuario == null)
                {
                    //Usuario y/o contraseña incorreta
                    ViewBag.viewError = true;
                    ViewBag.message = "Revisa tu usuario y contraseña.";
                    //Aumenta el numero de intentos fallidos si existe
                    var user = db.Usuarios.Where(x => x.Login == login.Username | x.CorreoElectronico == login.Username)
                                .FirstOrDefault();
                    if (user != null) {
                        user.IntentosFallidos += 1;
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                else
                {

                    System.Web.HttpContext.Current.Session["User"] = usuario;
                    var user = db.Usuarios.Where(x => x.Login == login.Username | x.CorreoElectronico == login.Username)
                                .FirstOrDefault();
                    if (user != null)
                    {
                        user.IntentosFallidos = 0;
                        db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        if (user.CambiarPassword)
                        {
                            return RedirectToAction("ChangePassword", "Home", login);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home", login);
                        }
                        
                    }
                    ///validar si debe cambiar contraseña
                    
                    
                    
                }
            }
            
                        

            return View("Index");
        }
    }
}
