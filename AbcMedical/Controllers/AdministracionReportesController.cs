using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Entities.Administracion.Reportes;
namespace AbcMedical.Controllers
{
    public class AdministracionReportesController : Controller
    {
        private AbcMedicalContext db = new AbcMedicalContext();

        // GET: Administracion
        public ActionResult PacientesActivos()
        {
            var resultado = db.Pacientes.Where(x => x.Activo == true).ToList();
            return View(resultado);
        }
        // GET: Administracion
        public ActionResult FiltrosHistoriasCreadas()
        {
            int CompanyClientId = 1;
            ViewBag.PuestoAtencionId = new SelectList(db.PuestoAtencions.Where(x => x.CompanyClientId == CompanyClientId), "PuestoAtencionId", "Descripcion");
            var profesionales = db.Profesionals.Where(x => x.Activo == true).Where(x => x.CompanyClientId == CompanyClientId).OrderBy(X => X.PrimerNombre).Select(x => new
            {
                Id = x.ProfesionalId,
                Texto = x.PrimerNombre + " " + x.SegundoNombre + " " + x.PrimerApellido + " " + x.SegundoApellido
            }).ToList();
            //PENDIENTE Filtro por companyclient
            ViewBag.ProfesionalId = new SelectList(profesionales, "Id", "Texto");
            ViewBag.DiagnosticoId = new SelectList(db.Diagnosticoes, "DiagnosticoId", "Descripcion");

            return View();
        }
        [HttpPost]
        public ActionResult FiltrosHistoriasCreadas(FiltrosHistoriasCreadas filtros)
        {
            int CompanyClientId = 1;
            if (ModelState.IsValid)
            {

                var historiasCreadas = db.RegistroHistoria.Where(x => x.CompanyCLientId == CompanyClientId).Where(x => x.ProfesionalId == filtros.ProfesionalId).ToList();

                return View("HistoriasCreadas", historiasCreadas.Where(X=>X.Fecha>=filtros.FechaInicio).Where(x=>x.Fecha<=filtros.FechaFin).ToList());
            }

            ViewBag.PuestoAtencionId = new SelectList(db.PuestoAtencions.Where(x => x.CompanyClientId == CompanyClientId), "PuestoAtencionId", "Descripcion");
            var profesionales = db.Profesionals.Where(x => x.Activo == true).Where(x => x.CompanyClientId == CompanyClientId).OrderBy(X => X.PrimerNombre).Select(x => new
            {
                Id = x.ProfesionalId,
                Texto = x.PrimerNombre + " " + x.SegundoNombre + " " + x.PrimerApellido + " " + x.SegundoApellido
            }).ToList();
            //PENDIENTE Filtro por companyclient
            ViewBag.ProfesionalId = new SelectList(profesionales, "Id", "Texto");
            ViewBag.DiagnosticoId = new SelectList(db.Diagnosticoes, "DiagnosticoId", "Descripcion");

            return View();
        }
    }
}