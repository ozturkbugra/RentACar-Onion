using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.CarDtos;
using RentACarApp.Dto.CarFeatureDtos;
using System.Net.Http;

namespace RentACarApp.WebUI.ViewComponents.CarDetailComponents
{
    public class _CarDetailTabPageCarFeatureComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailTabPageCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/CarFeatures?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = System.Text.Json.JsonSerializer.Deserialize<List<ResultListCarFeatureByCarIdDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
