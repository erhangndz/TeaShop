using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.FaqDtos;

namespace TeaShop.Presentation.ViewComponents.Default_Index
{
    public class _IndexFaq:ViewComponent
    {
        private readonly HttpClient _client;

        public _IndexFaq(HttpClient client)
        {
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string baseUri = "https://localhost:7248/api/Faq/";

            var values = await _client.GetFromJsonAsync<List<ResultFaqDto>>(baseUri);
            return View(values);

        }
    }
}
