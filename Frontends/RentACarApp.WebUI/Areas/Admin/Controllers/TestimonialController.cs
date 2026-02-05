using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentACarApp.Dto.TestimonialDtos;
using RentACarApp.Dto.BrandDtos;
using System.Text;

namespace RentACarApp.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/Admin/Testimonial")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7066/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("Create")]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7066/api/Testimonials", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new {area="Admin"});
            }
            return View();
        }

        [Route("Remove/{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7066/api/Testimonials/" + id);
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });

        }

        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage = await client.GetAsync("https://localhost:7066/api/Testimonials/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultTestimonialDto>(jsonData);
                return View(values);
            }
            return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
        }

        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(ResultTestimonialDto resultTestimonialDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(resultTestimonialDto);
            StringContent stringContent = new StringContent(JsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7066/api/Testimonials", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
            }
            return View(resultTestimonialDto);
        }
    }
}
