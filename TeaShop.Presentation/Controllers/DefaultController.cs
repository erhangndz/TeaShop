using Microsoft.AspNetCore.Mvc;

namespace TeaShop.Presentation.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
