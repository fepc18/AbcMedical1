using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Net;
using System;
using Entities.Administracion.Api;
using Action.Administracion;
namespace Api.Controllers
{
    public class PacienteApiController : ApiController
    {
        //[EnableCorsAttribute("*", "*", "")]
        [HttpGet]
    //    [ActionName("getPaciente")]
    //    [Route("getPaciente/")]
        public IHttpActionResult getPaciente(string PacienteDocument)
        {
            var action = new PacienteAction();
            return Ok(action.getPaciente(PacienteDocument));
        }
       
       
    }
}


