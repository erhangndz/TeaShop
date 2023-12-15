using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.SubscribeDtos;
using TeaShop.Presentation.Dtos.TestimonialDtos;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
   
    public class TestimonialController : Controller
    {
        private readonly HttpClient _client;

        public TestimonialController(HttpClient client)
        {
            _client = client;
        }

        string baseUri = "https://localhost:7248/api/Testimonials/";

        public async Task<IActionResult> Index()
        {

			
				var testimonials = await _client.GetFromJsonAsync<List<ResultTestimonialDto>>(baseUri);
				return View(testimonials);




			
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _client.DeleteAsync(baseUri + id);
            return RedirectToAction("Index");
        }

        public IActionResult CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            await _client.PostAsJsonAsync(baseUri, createTestimonialDto);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _client.GetFromJsonAsync<UpdateTestimonialDto>(baseUri + id);
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            await _client.PutAsJsonAsync(baseUri, updateTestimonialDto);
            return RedirectToAction("Index");
        }
    }
}
