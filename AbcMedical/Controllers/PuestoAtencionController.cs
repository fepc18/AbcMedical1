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
    public class PuestoAtencionController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: PuestoAtencion
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["CompanyClientId"] = 1;
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            var puestoAtencions = db.PuestoAtencions.Include(p => p.CompanyClient);
            return View(puestoAtencions.Where(x => x.CompanyClientId == CompanyClientId).ToList());
        }

        // GET: PuestoAtencion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuestoAtencion puestoAtencion = db.PuestoAtencions.Find(id);
            if (puestoAtencion == null)
            {
                return HttpNotFound();
            }
            return View(puestoAtencion);
        }

        // GET: PuestoAtencion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PuestoAtencion/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PuestoAtencion puestoAtencion)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            puestoAtencion.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.PuestoAtencions.Add(puestoAtencion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(puestoAtencion);
        }

        // GET: PuestoAtencion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuestoAtencion puestoAtencion = db.PuestoAtencions.Find(id);
            if (puestoAtencion == null)
            {
                return HttpNotFound();
            }
            return View(puestoAtencion);
        }

        // POST: PuestoAtencion/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( PuestoAtencion puestoAtencion)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            puestoAtencion.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Entry(puestoAtencion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", puestoAtencion.CompanyClientId);
            return View(puestoAtencion);
        }

        // GET: PuestoAtencion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PuestoAtencion puestoAtencion = db.PuestoAtencions.Find(id);
            if (puestoAtencion == null)
            {
                return HttpNotFound();
            }
            return View(puestoAtencion);
        }

        // POST: PuestoAtencion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PuestoAtencion puestoAtencion = db.PuestoAtencions.Find(id);
            db.PuestoAtencions.Remove(puestoAtencion);
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
