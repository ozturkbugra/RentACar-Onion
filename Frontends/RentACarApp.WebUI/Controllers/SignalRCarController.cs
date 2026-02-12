using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
