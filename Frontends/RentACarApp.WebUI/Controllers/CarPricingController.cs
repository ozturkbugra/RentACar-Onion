using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
