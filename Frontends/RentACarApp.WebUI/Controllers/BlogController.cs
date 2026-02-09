using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.BlogDtos;
using System.Threading.Tasks;

namespace RentACarApp.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Blogs/GetAllBlogsWithAuthor");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData =  await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthor>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> Detail(int id, int authorid)
        {
            ViewBag.BlogId = id;
            ViewBag.AuthorId = authorid;
            return View();
        }


        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(string p)
        {
            return View();
        }
    }
}
