using Microsoft.AspNetCore.Mvc;

namespace API_DCI_DIAGRAM_SVG.Controllers
{
    public class ApsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
