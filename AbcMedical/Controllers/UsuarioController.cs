using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Seguridad;

namespace AbcMedical.Controllers
{
    public class UsuarioController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Usuario
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["CompanyClientId"] = 1;
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            var usuarios = db.Usuarios.Include(u => u.CompanyClient).Include(u => u.Perfil);
            return View(usuarios.Where(x => x.CompanyClientId == CompanyClientId).ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Descripcion");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            usuario.CompanyClientId = CompanyClientId;
            usuario.FechaIngreso = new DateTime();
            usuario.Bloqueado = false;
            usuario.CambiarPassword = true;

            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Descripcion", usuario.PerfilId);
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", usuario.CompanyClientId);
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Descripcion", usuario.PerfilId);
            return View(usuario);
        }   

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsuarioId,CompanyClientId,Login,Password,CorreoElectronico,FechaIngreso,Activo,Bloqueado,PerfilId,CambiarPassword")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", usuario.CompanyClientId);
            ViewBag.PerfilId = new SelectList(db.Perfils, "PerfilId", "Descripcion", usuario.PerfilId);
            return View(usuario);
        }

        public ActionResult Desbloquear(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Desbloquear(Usuario usuario)
        {
            var user = db.Usuarios.Find(usuario.UsuarioId);
            user.Bloqueado = false;
            user.IntentosFallidos = 0;

            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ChangePassword change)
        {

            var usuario = db.Usuarios.Find(change.UsuarioId);
            if (usuario.Password.Equals(change.ClaveAntigua))
            {
                if (change.ClaveNueva.Equals(change.ConfirmarClaveNueva))
                {
                    usuario.Bloqueado = false;
                    usuario.IntentosFallidos = 0;
                    usuario.CambiarPassword = false;
                    usuario.Password = change.ClaveNueva;
                    db.Entry(usuario).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ViewBag.viewError = true;
                    ViewBag.message = "Verifica la confirmación de la contraseña.";
                }
            }
            else
            {
                ViewBag.viewError = true;
                ViewBag.message = "La contraseña actual no es correcta.";
            }
            return View();
        }

        public ActionResult ReasignarClave(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }            
            return View(usuario);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReasignarClave(Usuario usuario)
        {

            var user = db.Usuarios.Find(usuario.UsuarioId);
            user.Bloqueado = false;
            user.IntentosFallidos = 0;
            user.Password = usuario.Password;
            user.CambiarPassword = true;

            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            db.Usuarios.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword()
        {


            var user = (Usuario)System.Web.HttpContext.Current.Session["User"];
            ViewBag.Username = user.Login;
            //var user = db.Usuarios.Where(x => x.Login == login.Username).Where(x=>x.CompanyClientId==1).FirstOrDefault();            

            var change = new ChangePassword();
            change.UsuarioId = user.UsuarioId;

            return View(change);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
