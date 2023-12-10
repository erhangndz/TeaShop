using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Business.Abstract;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet]
        public IActionResult GetDrinkCount()
        {
            return Ok(_statisticsService.DrinkCount());
        }

        [HttpGet]
        public IActionResult GetLastDrinkName()
        {
            return Ok(_statisticsService.LastDrinkName());
        }

        [HttpGet]
        public IActionResult GetAvgDrinkPrice()
        {
            return Ok(_statisticsService.DrinkAvgPrice());
        }

        [HttpGet]
        public IActionResult GetMaxPriceDrink()
        {
            return Ok(_statisticsService.MaxPriceDrink());
        }
    }
}
