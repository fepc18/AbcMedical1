﻿using System;
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

                var perfilId = user.PerfilId;
                Opciones opciones = new Opciones();
                opciones.HistoriaClinica = estaOpcion(perfilId, "HistoriaClinica");
                ViewBag.HistoriaClinica = opciones.HistoriaClinica;

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
        public ActionResult goDigitalization()
        {

            return RedirectToAction("Index", "ArchivoDigital");
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
