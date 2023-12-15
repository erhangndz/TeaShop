using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
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

        [HttpGet]
        public IActionResult GetTestimonialCount()
        {
            return Ok(_statisticsService.GetTestimonialCount());
        }

        [HttpGet]
        public IActionResult GetMessageCount()
        {
            return Ok(_statisticsService.GetMessageCount());
        }

        [HttpGet]
        public IActionResult GetFaqCount()
        {
            return Ok(_statisticsService.GetFaqCount());
        }

        [HttpGet]
        public IActionResult GetSubscribeCount()
        {
            return Ok(_statisticsService.GetSubscriberCount());
        }
    }
}
