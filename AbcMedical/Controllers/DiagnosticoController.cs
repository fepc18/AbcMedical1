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
    public class DiagnosticoController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Diagnostico
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["CompanyClientId"] = 1;
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            var diagnosticoes = db.Diagnosticoes.Include(d => d.CompanyClient);
            return View(diagnosticoes.Where(x => x.CompanyClientId == CompanyClientId).ToList());
        }

        // GET: Diagnostico/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnosticoes.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // GET: Diagnostico/Create
        public ActionResult Create()
        {
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial");
            return View();
        }

        // POST: Diagnostico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Diagnostico diagnostico)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            diagnostico.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Diagnosticoes.Add(diagnostico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", diagnostico.CompanyClientId);
            return View(diagnostico);
        }

        // GET: Diagnostico/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnosticoes.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", diagnostico.CompanyClientId);
            return View(diagnostico);
        }

        // POST: Diagnostico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Diagnostico diagnostico)
        {

            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            diagnostico.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Entry(diagnostico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", diagnostico.CompanyClientId);
            return View(diagnostico);
        }

        // GET: Diagnostico/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Diagnostico diagnostico = db.Diagnosticoes.Find(id);
            if (diagnostico == null)
            {
                return HttpNotFound();
            }
            return View(diagnostico);
        }

        // POST: Diagnostico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Diagnostico diagnostico = db.Diagnosticoes.Find(id);
            db.Diagnosticoes.Remove(diagnostico);
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
