using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
