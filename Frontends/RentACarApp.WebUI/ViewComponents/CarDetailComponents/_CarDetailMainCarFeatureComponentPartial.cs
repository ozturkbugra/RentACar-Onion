using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.CarDtos;

namespace RentACarApp.WebUI.ViewComponents.CarDetailComponents
{
    public class _CarDetailMainCarFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Cars/GetCarByIdWithBrand/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = System.Text.Json.JsonSerializer.Deserialize<ResultCarWithBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
