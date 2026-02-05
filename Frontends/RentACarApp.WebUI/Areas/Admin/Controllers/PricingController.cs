using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.PricingDtos;
using RentACarApp.Dto.BrandDtos;
using System.Text;

namespace RentACarApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Pricing")]
    public class PricingController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PricingController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Pricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultPricingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreatePricingDto createPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createPricingDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7066/api/Pricings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Pricing", new {area="Admin"});
            }
            return View();
        }

        [Route("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7066/api/Pricings/" + id);
            return RedirectToAction("Index", "Pricing", new { area = "Admin" });

        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7066/api/Pricings/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultPricingDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("Index", "Pricing", new { area = "Admin" });
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(ResultPricingDto resultPricingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(resultPricingDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7066/api/Pricings", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Pricing", new { area = "Admin" });
            }
            return View(resultPricingDto);
        }
    }
}
