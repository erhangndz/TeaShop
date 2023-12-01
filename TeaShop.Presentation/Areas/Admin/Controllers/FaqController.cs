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
        private readonly IHttpClientFactory _httpClientFactory;

        public FaqController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7248/api/Faq");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonSerializer.Deserialize<List<ResultFaqDto>>(jsonData, CustomJson.Option);
                return View(values);
            }
            return View();
        }

        public IActionResult CreateFaq()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateFaq(CreateFaqDto createFaqDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonSerializer.Serialize(createFaqDto,CustomJson.Option);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7248/api/Faq", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateFaq(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7248/api/Faq/"+id);
            if(response.IsSuccessStatusCode)
            {
                var jsonData= await response.Content.ReadAsStringAsync();
                var value = JsonSerializer.Deserialize<UpdateFaqDto>(jsonData, CustomJson.Option);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateFaq(UpdateFaqDto updateFaqDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonSerializer.Serialize(updateFaqDto, CustomJson.Option);
            var content = new StringContent(jsonData,Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7248/api/Faq", content);
            if(response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteFaq(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync("https://localhost:7248/api/Faq/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
