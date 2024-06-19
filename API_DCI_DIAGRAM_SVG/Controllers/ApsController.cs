using API_DCI_DIAGRAM_SVG.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace API_DCI_DIAGRAM_SVG.Controllers
{
    public class ApsController : Controller
    {
        private readonly DBSCM efSCM = new DBSCM();
        [HttpPost]
        [Route("/aps/data")]
        public IActionResult ApsData()
        {
            return Ok();
        }
    }
}
