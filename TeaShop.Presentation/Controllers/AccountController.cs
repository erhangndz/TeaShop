using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NuGet.DependencyResolver;
using System.Reflection.Metadata;
using System.Text;
using TeaShop.Presentation.Models;

namespace TeaShop.Presentation.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly HttpClient _client;

        public AccountController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
        {

            TempData["registerPassword"]= registerViewModel.Password;
            var result = await _client.PostAsJsonAsync("https://localhost:7248/api/Account/Register", registerViewModel);

            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Login");
            }



            else
            {
                var registerJson= JsonConvert.SerializeObject(registerViewModel);
                var content = new StringContent(registerJson, Encoding.UTF8, "application/json");
                var response = await _client.PostAsync("https://localhost:7248/api/Account/Register", content);
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<IdentityError>>(jsonData);
              
                
                values.ForEach(x =>
                {
                    ModelState.AddModelError("", x.Description);
                   
                });
              
                return View();
              
            }
            


        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
            var result = await _client.PostAsJsonAsync("https://localhost:7248/api/Account/Login", model);
            if (result.IsSuccessStatusCode)
            {
               
                return RedirectToAction("Index", "Dashboard", new { area="Admin" });
            }
            ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Yanlış");
            return View();
        }
    }
}
