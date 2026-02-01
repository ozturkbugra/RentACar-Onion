using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.AboutDtos;
using RentACarApp.Dto.BannerDtos;

namespace RentACarApp.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultCoverUILayoutComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultCoverUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Banners");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = System.Text.Json.JsonSerializer.Deserialize<List<ResultBannerDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
