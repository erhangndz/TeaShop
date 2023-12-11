using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.AboutDtos;

namespace TeaShop.Presentation.ViewComponents.Default_Index
{
    public class _IndexAbout:ViewComponent
    {
        private readonly HttpClient _client;

        public _IndexAbout(HttpClient client)
        {
            _client = client;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            string baseUri = "https://localhost:7248/api/About/";
            var abouts = await _client.GetFromJsonAsync<List<ResultAboutDto>>(baseUri);
            return View(abouts);
        }
    }
}
