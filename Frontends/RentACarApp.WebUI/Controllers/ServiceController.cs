using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.ServiceDtos;
using System.Threading.Tasks;

namespace RentACarApp.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
