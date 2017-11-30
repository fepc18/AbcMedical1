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
    public class PerfilController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Perfil
        public ActionResult Index()
        {
            System.Web.HttpContext.Current.Session["CompanyClientId"] = 1;
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            var perfils = db.Perfils.Include(p => p.CompanyClient);
            return View(perfils.Where(x => x.CompanyClientId == CompanyClientId).ToList());
        }

        // GET: Perfil/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfils.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // GET: Perfil/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Perfil/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Perfil perfil)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            perfil.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Perfils.Add(perfil);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CompanyClientId = new SelectList(db.CompanyClient, "CompanyClientId", "RazonSocial", perfil.CompanyClientId);
            return View(perfil);
        }

        // GET: Perfil/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfils.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfil/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Perfil perfil)
        {
            int CompanyClientId = Convert.ToInt16(System.Web.HttpContext.Current.Session["CompanyClientId"]);
            perfil.CompanyClientId = CompanyClientId;
            if (ModelState.IsValid)
            {
                db.Entry(perfil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(perfil);
        }

        // GET: Perfil/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Perfil perfil = db.Perfils.Find(id);
            if (perfil == null)
            {
                return HttpNotFound();
            }
            return View(perfil);
        }

        // POST: Perfil/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Perfil perfil = db.Perfils.Find(id);
            db.Perfils.Remove(perfil);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        // GET:
        public ActionResult Permiso(int perfilId)
        {
            Opciones opciones = new Opciones();
            opciones.PuestosAtencion = estaOpcion(perfilId, "PuestosAtencion");
            opciones.Profesionales = estaOpcion(perfilId, "Profesionales");
            opciones.Especialidades = estaOpcion(perfilId, "Especialidades");
            opciones.Diagnosticos = estaOpcion(perfilId, "Diagnosticos");
            opciones.Pacientes = estaOpcion(perfilId, "Pacientes");
            opciones.PacientesActivos = estaOpcion(perfilId, "PacientesActivos");
            opciones.HistoriasCreadas = estaOpcion(perfilId, "HistoriasCreadas");


            opciones.HistoriaClinica = estaOpcion(perfilId, "HistoriaClinica");


            opciones.Usuarios = estaOpcion(perfilId, "Usuarios");
            opciones.Perfiles = estaOpcion(perfilId, "Perfiles");
            opciones.MatrizSeguridad = estaOpcion(perfilId, "MatrizSeguridad");
            opciones.Bitacora = estaOpcion(perfilId, "Bitacora");


            opciones.CargarArchivoDigital = estaOpcion(perfilId, "CargarArchivoDigital");
            opciones.TipoAnexo = estaOpcion(perfilId, "TipoAnexo");
            opciones.VolumenAlmacenamiento = estaOpcion(perfilId, "VolumenAlmacenamiento");


            //cargar permisos
            return View(opciones);
        }
        [HttpPost]
        public ActionResult Permiso(Opciones opciones)
        {
            if (opciones.Profesionales)
            {
                db.Permiso.Add(new Permiso { Opcion = "Profesionales", PerfilId = opciones.PerfilId, ModuloAplicacion = "Administracion", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("Profesionales", opciones.PerfilId);
            if (opciones.PuestosAtencion)
            {
                db.Permiso.Add(new Permiso { Opcion = "PuestosAtencion", PerfilId = opciones.PerfilId, ModuloAplicacion = "Administracion", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("PuestosAtencion", opciones.PerfilId);
            if (opciones.Especialidades)
            {
                db.Permiso.Add(new Permiso { Opcion = "Especialidades", PerfilId = opciones.PerfilId, ModuloAplicacion = "Administracion", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("Especialidades", opciones.PerfilId);
            if (opciones.Diagnosticos)
            {
                db.Permiso.Add(new Permiso { Opcion = "Diagnosticos", PerfilId = opciones.PerfilId, ModuloAplicacion = "Administracion", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("Diagnosticos", opciones.PerfilId);
            if (opciones.Pacientes)
            {
                db.Permiso.Add(new Permiso { Opcion = "Pacientes", PerfilId = opciones.PerfilId, ModuloAplicacion = "Administracion", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("Pacientes", opciones.PerfilId);
            if (opciones.PacientesActivos)
            {
                db.Permiso.Add(new Permiso { Opcion = "PacientesActivos", PerfilId = opciones.PerfilId, ModuloAplicacion = "Administracion", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("PacientesActivos", opciones.PerfilId);
            if (opciones.HistoriasCreadas)
            {
                db.Permiso.Add(new Permiso { Opcion = "HistoriasCreadas", PerfilId = opciones.PerfilId, ModuloAplicacion = "Administracion", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("HistoriasCreadas", opciones.PerfilId);
            ////////HISTORIA CLINICA

            if (opciones.HistoriasCreadas)
            {
                db.Permiso.Add(new Permiso { Opcion = "HistoriaClinica", PerfilId = opciones.PerfilId, ModuloAplicacion = "HistoriaClinica", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("HistoriaClinica", opciones.PerfilId);

            ////////SEGURIDAD

            if (opciones.Usuarios)
            {
                db.Permiso.Add(new Permiso { Opcion = "Usuarios", PerfilId = opciones.PerfilId, ModuloAplicacion = "Seguridad", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("Usuarios", opciones.PerfilId);
            

            if (opciones.Perfiles)
            {
                db.Permiso.Add(new Permiso { Opcion = "Perfiles", PerfilId = opciones.PerfilId, ModuloAplicacion = "Seguridad", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("Perfiles", opciones.PerfilId);
            

            if (opciones.MatrizSeguridad)
            {
                db.Permiso.Add(new Permiso { Opcion = "MatrizSeguridad", PerfilId = opciones.PerfilId, ModuloAplicacion = "Seguridad", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("MatrizSeguridad", opciones.PerfilId);
            if (opciones.Bitacora)
            {
                db.Permiso.Add(new Permiso { Opcion = "Bitacora", PerfilId = opciones.PerfilId, ModuloAplicacion = "Seguridad", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("Bitacora", opciones.PerfilId);

            ////////////DIGITALIZACION////////////////
            if (opciones.CargarArchivoDigital)
            {
                db.Permiso.Add(new Permiso { Opcion = "CargarArchivoDigital", PerfilId = opciones.PerfilId, ModuloAplicacion = "Seguridad", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("CargarArchivoDigital", opciones.PerfilId);

            if (opciones.TipoAnexo)
            {
                db.Permiso.Add(new Permiso { Opcion = "TipoAnexo", PerfilId = opciones.PerfilId, ModuloAplicacion = "Seguridad", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("TipoAnexo", opciones.PerfilId);

            if (opciones.VolumenAlmacenamiento)
            {
                db.Permiso.Add(new Permiso { Opcion = "VolumenAlmacenamiento", PerfilId = opciones.PerfilId, ModuloAplicacion = "Seguridad", Url = "" });
                db.SaveChanges();
            }
            else
                eliminarOpcion("VolumenAlmacenamiento", opciones.PerfilId);

            //cargar permisos
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
        public Boolean estaOpcion(int _perfilId, string _opcion)
        {
            Boolean resultado = false;
            var opcion = db.Permiso.Where(x => x.Opcion == _opcion).Where(x=>x.PerfilId==_perfilId).FirstOrDefault();
            if (opcion != null)
                resultado = true;
            return resultado;
        }
        public void eliminarOpcion(string opcion,int perfilId) {
            Permiso permiso = db.Permiso.Where(x=>x.PerfilId  == perfilId).Where(x=>x.Opcion==opcion).FirstOrDefault();
            if (permiso != null)
            {
                db.Permiso.Remove(permiso);
                db.SaveChanges();
            }
            
        }
    }
}
