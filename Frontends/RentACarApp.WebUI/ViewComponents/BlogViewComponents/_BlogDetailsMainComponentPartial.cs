using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.BlogDtos;
using RentACarApp.Dto.ServiceDtos;

namespace RentACarApp.WebUI.ViewComponents.BlogViewComponents
{
    public class _BlogDetailsMainComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _BlogDetailsMainComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7066/api/Blogs/"+ id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = System.Text.Json.JsonSerializer.Deserialize<ResultAllBlogsWithAuthor>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
