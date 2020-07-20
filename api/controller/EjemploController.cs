using System;
using System.Web.Http;
using System.Web.Routing;

namespace WebPay.api.controller
{
    [AllowAnonymous]
    [RoutePrefix("api/ejemplo")]
    public class EjemploController : ApiController
    {
        [HttpPost]
        [Route("objeto")]
        public IHttpActionResult EjemploObject([FromBody] Object obj)
        {
            if(obj != null)
            {

            }
            return BadRequest();
        }
    }
}
