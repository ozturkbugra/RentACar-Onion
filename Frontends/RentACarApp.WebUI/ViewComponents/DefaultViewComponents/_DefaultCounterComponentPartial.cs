using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.StatisticDtos;
using System.Net.Http;

namespace RentACarApp.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCounterComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCounterComponentPartial(IHttpClientFactory httpClientFactory)
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
