using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

public class AbcMedicalContext : DbContext
{
    // You can add custom code to this file. Changes will not be overwritten.
    // 
    // If you want Entity Framework to drop and regenerate your database
    // automatically whenever you change your model schema, please use data migrations.
    // For more information refer to the documentation:
    // http://msdn.microsoft.com/en-us/data/jj591621.aspx

    public AbcMedicalContext() : base("name=AbcMedicalContext")
    {
    }

    public System.Data.Entity.DbSet<Entities.Administracion.Especialidad> Especialidads { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.PuestoAtencion> PuestoAtencions { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.CompanyClient> CompanyClient { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Profesional> Profesionals { get; set; }
    public System.Data.Entity.DbSet<Entities.Administracion.ProfesionalFirma> ProfesionalFirma { get; set; }

    public System.Data.Entity.DbSet<Entities.Seguridad.Usuario> Usuarios { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Profesion> Profesions { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.TipoIdentificacion> TipoIdentificacion { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Diagnostico> Diagnosticoes { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Paciente> Pacientes { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Ciudad> Ciudads { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.EstadoCivil> EstadoCivils { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Regimen> Regimen { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Escolaridad> Escolaridads { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.Etnia> Etnias { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.TipoUsuario> TipoUsuarios { get; set; }

    public System.Data.Entity.DbSet<Entities.Administracion.TipoSangre> TipoSangres { get; set; }

    public System.Data.Entity.DbSet<Entities.Seguridad.Perfil> Perfils { get; set; }
    public System.Data.Entity.DbSet<Entities.Administracion.RegistroClinico> RegistroClinico { get; set; }
    public System.Data.Entity.DbSet<Entities.Historia.RegistroHistoria> RegistroHistoria { get; set; }

    public System.Data.Entity.DbSet<Entities.Seguridad.Log> Logs { get; set; }

    public System.Data.Entity.DbSet<Entities.ArchivoDigital.AnexoPaciente> AnexoPaciente { get; set; }
    public System.Data.Entity.DbSet<Entities.ArchivoDigital.Archivo> Archivo { get; set; }
    public System.Data.Entity.DbSet<Entities.ArchivoDigital.TipoAnexo> TipoAnexo { get; set; }
    public System.Data.Entity.DbSet<Entities.ArchivoDigital.Volumen> Volumen { get; set; }

    public System.Data.Entity.DbSet<Entities.Seguridad.Permiso> Permiso { get; set; }

}
