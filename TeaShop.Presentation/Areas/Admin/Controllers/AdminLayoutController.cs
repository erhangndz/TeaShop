using Microsoft.AspNetCore.Mvc;

namespace TeaShop.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]")]
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AdminSidebar()
        {
            return View();
        }
    }
}
