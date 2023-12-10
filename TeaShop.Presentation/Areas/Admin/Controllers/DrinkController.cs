using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Presentation.Configuration;
using TeaShop.Presentation.Dtos.DrinkDtos;
using System.Text;
using NuGet.DependencyResolver;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DrinkController : Controller
    {

        private readonly HttpClient _client;

        public DrinkController(HttpClient client)
        {

            _client = client;
        }
        Uri baseUri = new Uri("https://localhost:7248/api/Drinks");

        public async Task<IActionResult> Index()
        {
          
            var drinks = await _client.GetFromJsonAsync<List<ResultDrinkDto>>(baseUri);
            return View(drinks);

        }

        public IActionResult CreateDrink()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrink(CreateDrinkDto createDrinkDto)
        {
            await _client.PostAsJsonAsync(baseUri, createDrinkDto);
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> DeleteDrink(int id)
        {
            await _client.DeleteAsync($"{baseUri}/{id}");
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateDrink(int id)
        {
            var value = await _client.GetFromJsonAsync<UpdateDrinkDto>($"{baseUri}/{id}");
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDrink(UpdateDrinkDto updateDrinkDto)
        {
            await _client.PutAsJsonAsync(baseUri, updateDrinkDto);
            return RedirectToAction("Index");
        }

    }
}
