using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.BrandDtos;
using RentACarApp.Dto.FeatureDtos;
using System.Text;

namespace RentACarApp.WebUI.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminBrandController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> CreateBrand()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7066/api/Brands", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7066/api/Brands/" + id);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> UpdateBrand(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7066/api/Brands/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultBrandDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(ResultBrandDto resultBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(resultBrandDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7066/api/Brands", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(resultBrandDto);
        }
    }
}
