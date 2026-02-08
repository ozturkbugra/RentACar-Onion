using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
