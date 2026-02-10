using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.StatisticDtos;

namespace RentACarApp.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashBoardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashBoardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var model = new ResultStatisticDto();

            var response1 = await client.GetAsync("https://localhost:7066/api/Statistics/GetCarCount");
            if (response1.IsSuccessStatusCode)
            {
                var jsonData = await response1.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                model.CarCount = value.CarCount;
            }

            var response2 = await client.GetAsync("https://localhost:7066/api/Statistics/AvgCarPricingDaily");
            if (response2.IsSuccessStatusCode)
            {
                var jsonData = await response2.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                model.AvgCarPrice = value.AvgCarPrice;
            }

            var response3 = await client.GetAsync("https://localhost:7066/api/Statistics/MaxCarByBrand");
            if (response3.IsSuccessStatusCode)
            {
                var jsonData = await response3.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                model.MaxCarByBrand = value.MaxCarByBrand;
            }

            var response4 = await client.GetAsync("https://localhost:7066/api/Statistics/BrandCount");
            if (response4.IsSuccessStatusCode)
            {
                var jsonData = await response4.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<ResultStatisticDto>(jsonData);
                model.BrandCount = value.BrandCount;
            }

            return View(model);
        }
    }
}
