using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using TeaShop.Presentation.Configuration;
using TeaShop.Presentation.Dtos.FaqDtos;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class FaqController : Controller
    {
        private readonly HttpClient _client;

        public FaqController(HttpClient client)
        {
            _client = client;
        }
        string baseUri = "https://localhost:7248/api/Faq/";
        public async Task<IActionResult> Index()
        {
            var faqs = await _client.GetFromJsonAsync<List<ResultFaqDto>>(baseUri);
            return View(faqs);
        }
       
        public IActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFaq(CreateFaqDto createFaqDto)
        {
            await _client.PostAsJsonAsync(baseUri, createFaqDto);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> UpdateFaq(int id)
        {
            var faq = await _client.GetFromJsonAsync<UpdateFaqDto>(baseUri + id);
            return View(faq);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFaq(UpdateFaqDto updateFaqDto)
        {
            await _client.PutAsJsonAsync(baseUri, updateFaqDto);
            return RedirectToAction("Index");

        }

        public async Task<IActionResult> DeleteFaq(int id)
        {
            await _client.DeleteAsync(baseUri + id);
            return RedirectToAction("Index");
        }
    }
}
