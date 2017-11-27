using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Seguridad;
using System.Web.SessionState;
using AbcMedical.Service.Seguridad;
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
            try
            {
                ViewBag.viewError = false;

                var userGeneral = db.Usuarios.Where(x => x.Login == login.Username | x.CorreoElectronico == login.Username).FirstOrDefault();
                if (userGeneral != null)
                {
                    if (userGeneral.Bloqueado)
                    {
                        ViewBag.viewError = true;
                        ViewBag.message = "El usuario '"+login.Username+"' se encuentra BLOQUEADO, comuniquese con el administrador del sistema.";
                        new LogService().RegisterLog(new Log()
                        {
                            CompanyClientId = 1,
                            Fecha = DateTime.Now,
                            Usuario = login.Username,
                            Modulo = "Seguridad",
                            Descripcion = "El usuario '" + login.Username + "' se encuentra BLOQUEADO, comuniquese con el administrador del sistema."
                        });
                    }
                    else if (!userGeneral.Activo)
                    {
                        ViewBag.viewError = true;
                        ViewBag.message = "El usuario '" + login.Username + "' se encuentra INACTIVO, comuniquese con el administrador del sistema.";
                        new LogService().RegisterLog(new Log()
                        {
                            CompanyClientId = 1,
                            Fecha = DateTime.Now,
                            Usuario = login.Username,
                            Modulo = "Seguridad",
                            Descripcion = "El usuario '" + login.Username + "' se encuentra INACTIVO, comuniquese con el administrador del sistema."
                        });
                    }
                    else
                    {
                        var usuario = db.Usuarios.Where(x => x.Login == login.Username | x.CorreoElectronico == login.Username)
                                        .Where(x => x.Password == login.Password).FirstOrDefault();
                        if (usuario == null)
                        {
                            //Usuario y/o contraseña incorreta
                            ViewBag.viewError = true;
                            ViewBag.message = "Revisa tu usuario y contraseña.";
                            new LogService().RegisterLog(new Log()
                            {
                                CompanyClientId = 1,
                                Fecha = DateTime.Now,
                                Usuario = login.Username,
                                Modulo = "Seguridad",
                                Descripcion = "Error de inicio de sesion usuario: '" + login.Username + "'"
                            });
                            //Aumenta el numero de intentos fallidos si existe
                            var user = db.Usuarios.Where(x => x.Login == login.Username | x.CorreoElectronico == login.Username)
                                        .FirstOrDefault();
                            if (user != null)
                            {
                                user.IntentosFallidos += 1;
                                if (user.IntentosFallidos == 5)
                                {
                                    user.Bloqueado = true;
                                    new LogService().RegisterLog(new Log()
                                    {
                                        CompanyClientId = 1,
                                        Fecha = DateTime.Now,
                                        Usuario = login.Username,
                                        Modulo = "Seguridad",
                                        Descripcion = "Usuario '" + login.Username + "' bloqueado"
                                    });
                                }
                                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                                db.SaveChanges();
                                new LogService().RegisterLog(new Log()
                                {
                                    CompanyClientId = 1,
                                    Fecha = DateTime.Now,
                                    Usuario = login.Username,
                                    Modulo = "Seguridad",
                                    Descripcion = "Usuario '" + login.Username + "' registra intento de ingreso fallido"
                                });
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
                                new LogService().RegisterLog(new Log()
                                {
                                    CompanyClientId = 1,
                                    Fecha = DateTime.Now,
                                    Usuario = login.Username,
                                    Modulo = "Seguridad",
                                    Descripcion = "El usuario '" + login.Username + "' ingresa a la aplicación."
                                });
                                if (user.CambiarPassword)
                                {
                                    new LogService().RegisterLog(new Log()
                                    {
                                        CompanyClientId = 1,
                                        Fecha = DateTime.Now,
                                        Usuario = login.Username,
                                        Modulo = "Seguridad",
                                        Descripcion = "Se redirecciona a cambio de password."
                                    });
                                    return RedirectToAction("ChangePassword", "Usuario", login);
                                    
                                }
                                else
                                {
                                    new LogService().RegisterLog(new Log()
                                    {
                                        CompanyClientId = 1,
                                        Fecha = DateTime.Now,
                                        Usuario = login.Username,
                                        Modulo = "Seguridad",
                                        Descripcion = "Se redirecciona pantalla principal."
                                    });
                                    return RedirectToAction("Index", "Home", login);                                   
                                }
                            }
                            ///validar si debe cambiar contraseña
                        }
                    }
                }
                else
                {
                    ViewBag.viewError = true;
                    ViewBag.message = "El usuario no existe.";
                }
               
            }
            catch(Exception ex)
            {
                ViewBag.viewError = true;
                ViewBag.message = ex.ToString();
                new LogService().RegisterLog(new Log()
                {
                    CompanyClientId = 1,
                    Fecha = DateTime.Now,
                    Usuario = login.Username,
                    Modulo = "Seguridad",
                    Descripcion = ex.ToString()
                });
            }
            return View("Index");
        }
    }
}
