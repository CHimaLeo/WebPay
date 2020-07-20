using System;
using System.Text.Encodings.Web;
using System.Web.Http;
using WebPay.Models;
namespace WebPay.Controllers
{
    public class EjmController : ApiController
    {
        [Route("api/Ejm")]
        [HttpPost]
        public Boolean Algo(Response response)
        {
            Boolean algo = false;
            if(response.strResponse != null)
            {
                Prueba prueba = new Prueba();
                var originalString = System.Web.HttpUtility.UrlDecode(response.strResponse);   // Server.UrlDecode();    response.strResponse;
                string ejm = prueba.remplaza(originalString);
                string key = "5DCC67393750523CD165F17E1EFADD21";
                string decryptedString = prueba.desencripta(key, ejm);
                string json = prueba.CovertXmlaJSON(decryptedString);
                dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
                algo = true;
            }
            return algo;
        }
    }
}