using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Dashboard")]
    public class DashboardController : Controller
    {
        [Route("Index")]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
