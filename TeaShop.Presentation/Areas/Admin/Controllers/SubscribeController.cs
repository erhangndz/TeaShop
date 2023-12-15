using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.MessageDtos;
using TeaShop.Presentation.Dtos.SubscribeDtos;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
 
    public class SubscribeController : Controller
    {
        private readonly HttpClient _client;

        public SubscribeController(HttpClient client)
        {
            _client = client;
        }

        string baseUri = "https://localhost:7248/api/Subscribe/";

        public async Task<IActionResult> Index()
        {
			
				var subscribes = await _client.GetFromJsonAsync<List<ResultSubscribeDto>>(baseUri);
				return View(subscribes);


		


			
        }

        public async Task<IActionResult> DeleteSubscribe(int id)
        {
            await _client.DeleteAsync(baseUri + id);
            return RedirectToAction("Index");
        }

        
    }
}
