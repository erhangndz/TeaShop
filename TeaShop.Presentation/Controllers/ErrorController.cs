using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TeaShop.Presentation.Controllers
{
	[AllowAnonymous]
	public class ErrorController : Controller
	{
		public IActionResult Error404()
		{
			return View();
		}

		public IActionResult AccessDenied()
		{
			return View();
		}
	}
}
