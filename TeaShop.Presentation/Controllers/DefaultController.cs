using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.MessageDtos;
using TeaShop.Presentation.Dtos.SubscribeDtos;

namespace TeaShop.Presentation.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        private readonly HttpClient _client;

        public DefaultController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            createMessageDto.SendDate = DateTime.Now;
          await _client.PostAsJsonAsync("https://localhost:7248/api/Message/", createMessageDto);

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscribeDto createSubscribeDto)
        {
            await _client.PostAsJsonAsync("https://localhost:7248/api/Subscribe/",createSubscribeDto);

            return NoContent();
        }


    }



}
