using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.AboutDtos;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class AboutController : Controller
    {
        private readonly HttpClient _client;

        public AboutController(HttpClient client)
        {
            _client = client;
        }
        string baseUri = "https://localhost:7248/api/About/";
        public async Task<IActionResult> Index()
        {
            var abouts = await _client.GetFromJsonAsync<List<ResultAboutDto>>(baseUri);
            return View(abouts);
        }

        public async Task<IActionResult> DeleteAbout(int id)
        {
            await _client.DeleteAsync(baseUri + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateAbout(int id)
        {
            var about = await _client.GetFromJsonAsync<UpdateAboutDto>(baseUri + id);
            return View(about);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _client.PutAsJsonAsync(baseUri, updateAboutDto);
            return RedirectToAction("Index");
        }

        public IActionResult CreateAbout()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _client.PostAsJsonAsync(baseUri, createAboutDto);
            return RedirectToAction("Index");
        }
    }
}
