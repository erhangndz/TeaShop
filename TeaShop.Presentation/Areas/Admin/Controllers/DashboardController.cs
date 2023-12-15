using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Presentation.Configuration;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
   
    public class DashboardController : Controller
    {
        private readonly HttpClient _client;

        public DashboardController(HttpClient client)
        {
            _client = client;
        }

        public async Task<IActionResult> Index()
        {
            string baseUri = "https://localhost:7248/api/Statistics/";

            ViewBag.drinkCount = await _client.GetStringAsync( baseUri +"GetDrinkCount");
            
            ViewBag.lastDrinkName = await _client.GetStringAsync(baseUri+ "GetLastDrinkName");
           
            var price  = await _client.GetStringAsync(baseUri + "GetAvgDrinkPrice");
            ViewBag.avgDrinkPrice = price.ToString().Substring(0,5);


            ViewBag.maxPriceDrink = await _client.GetStringAsync(baseUri + "GetMaxPriceDrink");
          
            ViewBag.testimonialCount = await _client.GetStringAsync(baseUri + "GetTestimonialCount");
             
            ViewBag.messageCount= await _client.GetStringAsync(baseUri + "GetMessageCount");


            ViewBag.faqCount= await _client.GetStringAsync(baseUri + "GetFaqCount");

            ViewBag.subscribeCount= await _client.GetStringAsync(baseUri + "GetSubscribeCount");

            return View();
        }
    }
}
