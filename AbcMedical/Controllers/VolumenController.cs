using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities.ArchivoDigital;

namespace ArchivoDigital.Controllers
{
    public class VolumenController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Volumen
        public ActionResult Index()
        {
            return View(db.Volumen.ToList());
        }

        // GET: Volumen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volumen volumen = db.Volumen.Find(id);
            if (volumen == null)
            {
                return HttpNotFound();
            }
            return View(volumen);
        }

        // GET: Volumen/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Volumen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VolumenId,UrlVolumen,Activo")] Volumen volumen)
        {
            volumen.Usuario = "";// System.Web.HttpContext.Current.Session["User"].ToString();
            volumen.FechaCreacion = DateTime.Now;
            volumen.CompanyClientId = 1;
            if (ModelState.IsValid)
            {
                
                db.Volumen.Add(volumen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(volumen);
        }

        // GET: Volumen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volumen volumen = db.Volumen.Find(id);
            if (volumen == null)
            {
                return HttpNotFound();
            }
            return View(volumen);
        }

        // POST: Volumen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VolumenId,UrlVolumen,Activo,FechaCreacion,Usuario")] Volumen volumen)
        {
            volumen.CompanyClientId = 1;
            if (ModelState.IsValid)
            {
                db.Entry(volumen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(volumen);
        }

        // GET: Volumen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Volumen volumen = db.Volumen.Find(id);
            if (volumen == null)
            {
                return HttpNotFound();
            }
            return View(volumen);
        }

        // POST: Volumen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Volumen volumen = db.Volumen.Find(id);
            db.Volumen.Remove(volumen);
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
