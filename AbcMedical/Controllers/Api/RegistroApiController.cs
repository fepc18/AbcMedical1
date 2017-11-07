using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using System.Net;
using System;
using Entities.Administracion.Api;
using Action.Administracion;
namespace Api.Controllers
{
    public class RegistroApiController : ApiController
    {
        //[EnableCorsAttribute("*", "*", "")]
        [HttpPost]
    //    [ActionName("getPaciente")]
    //    [Route("getPaciente/")]
        public IHttpActionResult getRegistros(InGetRegistros Input)
        {
            var action = new RegistroClinicoAction();
            return Ok(action.getRegistros(Input));
        }
       
       
    }
}


