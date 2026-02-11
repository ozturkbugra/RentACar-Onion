using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.CarDtos;
using RentACarApp.Dto.ServiceDtos;

namespace RentACarApp.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Cars/GetCarsWithPricing");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = System.Text.Json.JsonSerializer.Deserialize<List<ResultCarsWithPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Detail()
        {
            return View();
        }
    }
}
