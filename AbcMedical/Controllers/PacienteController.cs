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
    public class PacienteController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Paciente
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["CompanyClientId"] = 1;
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            var pacientes = db.Pacientes.Include(p => p.Ciudad).Include(p => p.CompanyClient).Include(p => p.Escolaridad).Include(p => p.EstadoCivil).Include(p => p.Etnia).Include(p => p.Profesion).Include(p => p.Regimen).Include(p => p.TipoIdentificacion).Include(p => p.TipoSangre).Include(p => p.TipoUsuario);
            return View(pacientes.Where(x => x.CompanyClientId == CompanyClientId).ToList());
        }

        // GET: Paciente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Paciente/Create
        public ActionResult Create()
        {
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Descripcion");
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial");
            ViewBag.EscolaridadId = new SelectList(db.Escolaridads, "EscolaridadId", "Descripcion");
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivils, "EstadoCivilId", "Descripcion");
            ViewBag.EtniaId = new SelectList(db.Etnias, "EtniaId", "Descripcion");
            ViewBag.ProfesionId = new SelectList(db.Profesions, "ProfesionId", "Descripcion");
            ViewBag.RegimenId = new SelectList(db.Regimen, "RegimenId", "Descripcion");
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion");
            ViewBag.TipoSangreId = new SelectList(db.TipoSangres, "TipoSangreId", "Descripcion");
            ViewBag.TipoUsuarioId = new SelectList(db.TipoUsuarios, "TipoUsuarioId", "Descripcion");
            return View();
        }

        // POST: Paciente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Paciente paciente)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            paciente.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Pacientes.Add(paciente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Descripcion", paciente.CiudadId);
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", paciente.CompanyClientId);
            ViewBag.EscolaridadId = new SelectList(db.Escolaridads, "EscolaridadId", "Descripcion", paciente.EscolaridadId);
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivils, "EstadoCivilId", "Descripcion", paciente.EstadoCivilId);
            ViewBag.EtniaId = new SelectList(db.Etnias, "EtniaId", "Descripcion", paciente.EtniaId);
            ViewBag.ProfesionId = new SelectList(db.Profesions, "ProfesionId", "Descripcion", paciente.ProfesionId);
            ViewBag.RegimenId = new SelectList(db.Regimen, "RegimenId", "Descripcion", paciente.RegimenId);
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", paciente.TipoIdentificacionId);
            ViewBag.TipoSangreId = new SelectList(db.TipoSangres, "TipoSangreId", "Descripcion", paciente.TipoSangreId);
            ViewBag.TipoUsuarioId = new SelectList(db.TipoUsuarios, "TipoUsuarioId", "Descripcion", paciente.TipoUsuarioId);
            return View(paciente);
        }

        // GET: Paciente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Descripcion", paciente.CiudadId);
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", paciente.CompanyClientId);
            ViewBag.EscolaridadId = new SelectList(db.Escolaridads, "EscolaridadId", "Descripcion", paciente.EscolaridadId);
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivils, "EstadoCivilId", "Descripcion", paciente.EstadoCivilId);
            ViewBag.EtniaId = new SelectList(db.Etnias, "EtniaId", "Descripcion", paciente.EtniaId);
            ViewBag.ProfesionId = new SelectList(db.Profesions, "ProfesionId", "Descripcion", paciente.ProfesionId);
            ViewBag.RegimenId = new SelectList(db.Regimen, "RegimenId", "Descripcion", paciente.RegimenId);
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", paciente.TipoIdentificacionId);
            ViewBag.TipoSangreId = new SelectList(db.TipoSangres, "TipoSangreId", "Descripcion", paciente.TipoSangreId);
            ViewBag.TipoUsuarioId = new SelectList(db.TipoUsuarios, "TipoUsuarioId", "Descripcion", paciente.TipoUsuarioId);
            return View(paciente);
        }

        // POST: Paciente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(paciente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CiudadId = new SelectList(db.Ciudads, "CiudadId", "Descripcion", paciente.CiudadId);
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", paciente.CompanyClientId);
            ViewBag.EscolaridadId = new SelectList(db.Escolaridads, "EscolaridadId", "Descripcion", paciente.EscolaridadId);
            ViewBag.EstadoCivilId = new SelectList(db.EstadoCivils, "EstadoCivilId", "Descripcion", paciente.EstadoCivilId);
            ViewBag.EtniaId = new SelectList(db.Etnias, "EtniaId", "Descripcion", paciente.EtniaId);
            ViewBag.ProfesionId = new SelectList(db.Profesions, "ProfesionId", "Descripcion", paciente.ProfesionId);
            ViewBag.RegimenId = new SelectList(db.Regimen, "RegimenId", "Descripcion", paciente.RegimenId);
            ViewBag.TipoIdentificacionId = new SelectList(db.TipoIdentificacion, "TipoIdentificacionId", "Descripcion", paciente.TipoIdentificacionId);
            ViewBag.TipoSangreId = new SelectList(db.TipoSangres, "TipoSangreId", "Descripcion", paciente.TipoSangreId);
            ViewBag.TipoUsuarioId = new SelectList(db.TipoUsuarios, "TipoUsuarioId", "Descripcion", paciente.TipoUsuarioId);
            return View(paciente);
        }

        // GET: Paciente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Paciente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
