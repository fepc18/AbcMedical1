using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Administracion
{
    [Table("Paciente")]
    public class Paciente
    {
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Id")]
        public int PacienteId { get; set; }
        public int CompanyClientId { get; set; }
        public virtual CompanyClient CompanyClient { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo de Identificación")]
        public int TipoIdentificacionId { get; set; }
        public virtual TipoIdentificacion TipoIdentificacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Nombre")]
        public string PrimerNombre { get; set; }
        [Display(Name = "Segundo Nombre")]
        public string SegundoNombre { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Primer Apellido")]
        public string PrimerApellido { get; set; }
        [Display(Name = "Segundo Apellido")]
        public string SegundoApellido { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Fecha de Nacimiento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Régimen")]
        public int RegimenId { get; set; }
        public virtual Regimen Regimen { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Profesión")]
        public int ProfesionId { get; set; }
        public virtual Profesion Profesion { get; set; }
        public int Nivel { get; set; }
        public string Zona { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Estado Civil")]
        public int EstadoCivilId { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Tipo de Usuario")]
        public int TipoUsuarioId { get; set; }
        public virtual TipoUsuario TipoUsuario { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        public string Barrio { get; set; }
        public int CiudadId { get; set; }
        public virtual Ciudad Ciudad { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Teléfono de Residencia")]
        public string TelefonoResidencia { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Teléfono de Oficina")]
        public string TelefonoOficina { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Celular")]
        public string Celular { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        [Display(Name = "Correo Electrónico")]
        public string CorreoElectronico { get; set; }        
        [Required(ErrorMessage = "Tipo de Sangre")]
        [Display(Name = "Tipo de Sangre")]
        public int TipoSangreId { get; set; }
        public TipoSangre TipoSangre { get; set; }
        public int EtniaId { get; set; }
        public virtual Etnia Etnia { get; set; }
        public int EscolaridadId { get; set; }
        public virtual Escolaridad Escolaridad { get; set; }
        [Display(Name = "Fecha de Afiliación")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaAfiliacion { get; set; }
        public Boolean Activo { get; set; }
    }
    

}
