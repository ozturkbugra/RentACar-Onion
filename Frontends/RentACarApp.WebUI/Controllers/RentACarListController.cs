using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.RentACarDtos;
using System.Text;

namespace RentACarApp.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(string book_pick_date, string book_off_date, string time_pick, string time_off, int locationID)
        {
            FilterRentACarDto filter = new FilterRentACarDto();
            filter.locationID = Convert.ToInt32(locationID);
            filter.available = true;

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(filter);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7066/api/RentACars", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
