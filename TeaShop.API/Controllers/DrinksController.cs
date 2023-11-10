using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetDrinks()
        {
            return Ok();
        }

    }
}
