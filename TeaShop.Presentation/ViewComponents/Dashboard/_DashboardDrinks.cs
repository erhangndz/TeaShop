using Microsoft.AspNetCore.Mvc;
using TeaShop.Presentation.Dtos.DrinkDtos;

namespace TeaShop.Presentation.ViewComponents.Dashboard
{
    public class _DashboardDrinks:ViewComponent
    {
        private readonly HttpClient _client;

        public _DashboardDrinks(HttpClient client)
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
