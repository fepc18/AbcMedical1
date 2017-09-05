using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.Administracion;

namespace AbcMedical.Controllers
{
    public class ProfesionalController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Profesional
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["CompanyClientId"] = 1;
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            var profesionals = db.Profesionals.Include(p => p.Especialidad).Include(p => p.TipoIdentificacion).Include(p => p.Usuario);
            //return View(profesionals.Where(x => x.CompanyClientId == CompanyClientId).ToList());
            return View(profesionals.ToList());
        }

        // GET: Profesional/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesionals.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // GET: Profesional/Create
        public ActionResult Create()
        {
            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "EspecialidadId", "Descripcion");
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Login");
            return View();
        }

        // POST: Profesional/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Profesional profesional)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            profesional.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Profesionals.Add(profesional);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "EspecialidadId", "Descripcion", profesional.EspecialidadId);
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", profesional.TipoIdentificacionId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Login", profesional.UsuarioId);
            return View(profesional);
        }

        // GET: Profesional/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesionals.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "EspecialidadId", "Descripcion", profesional.EspecialidadId);
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", profesional.TipoIdentificacionId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Login", profesional.UsuarioId);
            return View(profesional);
        }

        // POST: Profesional/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Profesional profesional)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            profesional.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Entry(profesional).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.EspecialidadId = new SelectList(db.Especialidads, "EspecialidadId", "Descripcion", profesional.EspecialidadId);
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", profesional.TipoIdentificacionId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "UsuarioId", "Login", profesional.UsuarioId);
            return View(profesional);
        }

        // GET: Profesional/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesional profesional = db.Profesionals.Find(id);
            if (profesional == null)
            {
                return HttpNotFound();
            }
            return View(profesional);
        }

        // POST: Profesional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesional profesional = db.Profesionals.Find(id);
            db.Profesionals.Remove(profesional);
            db.SaveChanges();
            return RedirectToAction("Index");
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
