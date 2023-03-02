using Microsoft.AspNetCore.Mvc;
using webApi.Data;

namespace webApi.Controllers
{
    [ApiController]
    [Route("api/acuario")]
    public class AcuarioController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Acuario>> Get()
        {
            return new List<Acuario>()
            {
                new Acuario() {Acuario_ID=1, Nombre_Acuario="fish", ubicacion="nuevo leon", maximo_visitantes=300},
                new Acuario(){Acuario_ID=2, Nombre_Acuario="nemo",ubicacion="peru",maximo_visitantes=5000}
            };
        }
    }
}
