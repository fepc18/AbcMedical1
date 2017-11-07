using System.Web.Http;
using Entities.Historia;
using Entities.Historia.Api;
using Action.Historia;
using System.Net.Http;

namespace Api.Controllers
{
    public class RegistroHistoriaApiController : ApiController
    {
      
        [HttpPost]    
        public IHttpActionResult saveRegistroHistoria([FromBody]RegistroHistoria Input)
        {
            var action = new RegistroHistoriaAction();
            return Ok(action.saveRegistroHistoria(Input));
        }

        [HttpPost]
        [ActionName("getHistorialRegistros")]
        public IHttpActionResult getHistorialRegistros([FromBody]InGetRegistrosHistorial Input)
        {
            var action = new RegistroHistoriaAction();
            return Ok(action.getHistorialRegistros(Input));
        }

        [HttpPost]
        [ActionName("getResumenHistorialRegistros")]
        public IHttpActionResult getResumenHistorialRegistros([FromBody] InGetRegistrosHistorial Input)
        {
            var action = new RegistroHistoriaAction();
            return Ok(action.getResumenHistorialRegistros(Input));
        }

        [HttpGet]
        [ActionName("getPDF")]
        public HttpResponseMessage getPDF(string RegistroHistoriaId)
        {
            var action = new RegistroHistoriaAction();
            return action.getPDF(RegistroHistoriaId);
        }
    }
}


