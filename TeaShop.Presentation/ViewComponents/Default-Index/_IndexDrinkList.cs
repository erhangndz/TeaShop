using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Presentation.Configuration;
using TeaShop.Presentation.Dtos.DrinkDtos;

namespace TeaShop.Presentation.ViewComponents.Default_Index
{
    public class _IndexDrinkList:ViewComponent
    {
        
        private readonly HttpClient _client;

        public _IndexDrinkList( HttpClient client)
        {
            
            _client = client;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var drinks = await _client.GetFromJsonAsync<List<ResultDrinkDto>>("https://localhost:7248/api/Drinks");
            
            return View(drinks);

        }
    }
}
