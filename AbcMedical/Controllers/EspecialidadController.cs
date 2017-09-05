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
    public class EspecialidadController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Especialidad
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["CompanyClientId"]=1;
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            return View(db.Especialidads.Where(x=>x.CompanyClientId==CompanyClientId).ToList());
        }

        // GET: Especialidad/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidads.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // GET: Especialidad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Especialidad/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Especialidad especialidad)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            especialidad.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Especialidads.Add(especialidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(especialidad);
        }

        // GET: Especialidad/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidads.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidad/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Especialidad especialidad)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            especialidad.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Entry(especialidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(especialidad);
        }

        // GET: Especialidad/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Especialidad especialidad = db.Especialidads.Find(id);
            if (especialidad == null)
            {
                return HttpNotFound();
            }
            return View(especialidad);
        }

        // POST: Especialidad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Especialidad especialidad = db.Especialidads.Find(id);
            db.Especialidads.Remove(especialidad);
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
