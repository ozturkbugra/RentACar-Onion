using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.BlogDtos;
using RentACarApp.Dto.CarFeatureDtos;
using RentACarApp.Dto.CategoryDtos;
using RentACarApp.Dto.FeatureDtos;
using System.Text;

namespace RentACarApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/CarFeature")]
    public class CarFeatureController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarFeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultListCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("Index/{id}")]
        public async Task<IActionResult> Index(int id, List<ResultListCarFeatureByCarIdDto> dto)
        {
            var client = _httpClientFactory.CreateClient();

            foreach (var item in dto)
            {
                if (item.available)
                {
                    await client.GetAsync("https://localhost:7066/api/CarFeatures/CarFeatureChangeAvailableToTrue?id=" + item.carFeatureID);
                }
                else
                {
                    await client.GetAsync("https://localhost:7066/api/CarFeatures/CarFeatureChangeAvailableToFalse?id=" + item.carFeatureID);
                }
            }

            return RedirectToAction("Index", new { id = id });
        }


        [Route("CreateFeatureByCarID")]
        public async Task<IActionResult> CreateFeatureByCarID()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
