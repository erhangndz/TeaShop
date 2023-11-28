using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Dto.Dtos.DrinkDtos;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]")]
	public class DrinkController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		

        public DrinkController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            
        }

		
        public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7248/api/Drinks");
			if(response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                   
                    PropertyNameCaseInsensitive = true 
                };
                var drinks = JsonSerializer.Deserialize<List<GetDrinkDto>>(jsonData,options);
				
				return View(drinks);
			}
			return View();
			
		}
	}
}
