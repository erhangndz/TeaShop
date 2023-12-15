using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.MessageDtos;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
   
    public class MessageController : Controller
    {
        private readonly HttpClient _client;

        public MessageController(HttpClient client)
        {
            _client = client;
        }
        string baseUri = "https://localhost:7248/api/Message/";

        public async Task<IActionResult> Index()
        {
            var messages = await _client.GetFromJsonAsync<List<ResultMessageDto>>(baseUri);
            return View(messages);
        }

       public async Task<IActionResult> DeleteMessage(int id)
        {
            await _client.DeleteAsync(baseUri + id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> MessageDetail(int id)
        {
            var message= await _client.GetFromJsonAsync<ResultMessageDto>(baseUri + id);
            return View(message);
        }

        
    }
}
