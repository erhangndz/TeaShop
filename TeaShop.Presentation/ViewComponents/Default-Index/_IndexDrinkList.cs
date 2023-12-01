using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Presentation.Configuration;
using TeaShop.Presentation.Dtos.DrinkDtos;

namespace TeaShop.Presentation.ViewComponents.Default_Index
{
    public class _IndexDrinkList:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _IndexDrinkList(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7248/api/Drinks");
            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonSerializer.Deserialize<List<ResultDrinkDto>>(jsonData, CustomJson.Option);
                return View(values);
            }
            return View();
        }
    }
}
