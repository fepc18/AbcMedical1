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
    public class ProfesionController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Profesion
        public ActionResult Index()
        {
            var profesions = db.Profesions.Include(p => p.CompanyClient);
            return View(profesions.ToList());
        }

        // GET: Profesion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesion profesion = db.Profesions.Find(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            return View(profesion);
        }

        // GET: Profesion/Create
        public ActionResult Create()
        {
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial");
            return View();
        }

        // POST: Profesion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfesionId,CompanyClientId,Descripcion")] Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                db.Profesions.Add(profesion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", profesion.CompanyClientId);
            return View(profesion);
        }

        // GET: Profesion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesion profesion = db.Profesions.Find(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", profesion.CompanyClientId);
            return View(profesion);
        }

        // POST: Profesion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfesionId,CompanyClientId,Descripcion")] Profesion profesion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(profesion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", profesion.CompanyClientId);
            return View(profesion);
        }

        // GET: Profesion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Profesion profesion = db.Profesions.Find(id);
            if (profesion == null)
            {
                return HttpNotFound();
            }
            return View(profesion);
        }

        // POST: Profesion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Profesion profesion = db.Profesions.Find(id);
            db.Profesions.Remove(profesion);
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
