using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using TeaShop.Presentation.Configuration;
using TeaShop.Presentation.Dtos.DrinkDtos;
using System.Text;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DrinkController : Controller
    {


        HttpClient client = new HttpClient();

        public async Task<IActionResult> Index()
        {

            var response = await client.GetAsync("https://localhost:7248/api/Drinks");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();

                var drinks = JsonSerializer.Deserialize<List<ResultDrinkDto>>(jsonData, CustomJson.Option);

                return View(drinks);
            }
            return View();

        }

        public IActionResult CreateDrink()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDrink(CreateDrinkDto createDrinkDto)
        {

            var jsonData = JsonSerializer.Serialize(createDrinkDto, CustomJson.Option);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7248/api/Drinks", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }


        public async Task<IActionResult> DeleteDrink(int id)
        {

            var response = await client.DeleteAsync("https://localhost:7248/api/Drinks/" + id);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();



        }

        public async Task<IActionResult> UpdateDrink(int id)
        {

            var response = await client.GetAsync("https://localhost:7248/api/Drinks/" + id);
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var drink = JsonSerializer.Deserialize<UpdateDrinkDto>(jsonData, CustomJson.Option);
                return View(drink);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDrink(UpdateDrinkDto updateDrinkDto)
        {

            var jsonData = JsonSerializer.Serialize(updateDrinkDto, CustomJson.Option);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7248/api/Drinks?id=", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

    }
}
