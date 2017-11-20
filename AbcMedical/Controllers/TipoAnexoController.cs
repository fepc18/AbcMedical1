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
    public class TipoAnexoController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: TipoAnexo
        public ActionResult Index()
        {
            return View(db.TipoAnexo.ToList());
        }

        // GET: TipoAnexo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnexo tipoAnexo = db.TipoAnexo.Find(id);
            if (tipoAnexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnexo);
        }

        // GET: TipoAnexo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoAnexo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TipoAnexoId,Descripcion")] TipoAnexo tipoAnexo)
        {
            tipoAnexo.CompanyClientId = 1;
            if (ModelState.IsValid)
            {
                db.TipoAnexo.Add(tipoAnexo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoAnexo);
        }

        // GET: TipoAnexo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnexo tipoAnexo = db.TipoAnexo.Find(id);
            if (tipoAnexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnexo);
        }

        // POST: TipoAnexo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TipoAnexoId,Descripcion")] TipoAnexo tipoAnexo)
        {
            tipoAnexo.CompanyClientId = 1;
            if (ModelState.IsValid)
            {
                db.Entry(tipoAnexo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoAnexo);
        }

        // GET: TipoAnexo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoAnexo tipoAnexo = db.TipoAnexo.Find(id);
            if (tipoAnexo == null)
            {
                return HttpNotFound();
            }
            return View(tipoAnexo);
        }

        // POST: TipoAnexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoAnexo tipoAnexo = db.TipoAnexo.Find(id);
            db.TipoAnexo.Remove(tipoAnexo);
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
