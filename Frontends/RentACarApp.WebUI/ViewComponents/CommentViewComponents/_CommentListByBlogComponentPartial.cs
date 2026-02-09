using Microsoft.AspNetCore.Mvc;
using RentACarApp.Dto.CommentDtos;

namespace RentACarApp.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var client = _httpClientFactory.CreateClient();

            // Boş gelirse hata vermemesi için
            var model = new CommentListViewModel
            {
                Comments = new List<ResultCommentDto>(),
                CommentCount = 0
            };

            //Yorumları çekiyoruz
            var responseMessage = await client.GetAsync($"https://localhost:7066/api/Comments/CommentListByBlog/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                model.Comments = System.Text.Json.JsonSerializer
                    .Deserialize<List<ResultCommentDto>>(jsonData);
            }

            // Yorum Sayısını Çekiyoruz
            var responseMessage2 = await client.GetAsync($"https://localhost:7066/api/Comments/CommentsCount/{id}");
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                model.CommentCount = System.Text.Json.JsonSerializer
                    .Deserialize<int>(jsonData2);
            }

            return View(model);
        }

    }
}
