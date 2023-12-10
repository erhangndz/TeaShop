using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Presentation.Configuration;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            string baseUri = "https://localhost:7248/api/Statistics/";
            var client = _httpClientFactory.CreateClient();
            var response1 = await client.GetAsync( baseUri +"GetDrinkCount");
            var jsonData1= await response1.Content.ReadAsStringAsync();
            ViewBag.drinkCount = jsonData1;

            var response2 = await client.GetAsync(baseUri+ "GetLastDrinkName");
            var jsonData2 =await  response2.Content.ReadAsStringAsync();
            ViewBag.lastDrinkName = jsonData2;

            var response3 = await client.GetAsync(baseUri + "GetAvgDrinkPrice");
            var jsonData3 = await response3.Content.ReadAsStringAsync();
            ViewBag.avgDrinkPrice = jsonData3;

            var response4 = await client.GetAsync(baseUri + "GetMaxPriceDrink");
            var jsonData4 = await response4.Content.ReadAsStringAsync();
            ViewBag.maxPriceDrink = jsonData4;
            return View();
        }
    }
}
