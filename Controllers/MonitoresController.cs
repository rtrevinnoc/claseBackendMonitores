using Microsoft.AspNetCore.Mvc;
using Monitores.Entidades;

namespace Monitores.Controllers
{
    [ApiController]
    [Route("api/monitores")]
    public class MonitoresController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<EMonitor>> Get()
        {
            return new List<EMonitor>() {
                new EMonitor() { Id = 1, Nombre = "Monitor 1" },
                new EMonitor() { Id = 2, Nombre = "Monitor 2" }
            };
        }
    }
}
