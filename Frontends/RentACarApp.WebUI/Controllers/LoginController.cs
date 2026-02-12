using Microsoft.AspNetCore.Mvc;

namespace RentACarApp.WebUI.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string q)
        {
            return View();
        }


    }
}
