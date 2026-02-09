using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/CarFeature")]
    public class CarFeatureController : Controller
    {
        [Route("Index/{id}")]
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
