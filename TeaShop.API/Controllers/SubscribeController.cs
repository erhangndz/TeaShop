using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Business.Abstract;
using TeaShop.Dto.Dtos.SubscribeDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {

        private readonly IGenericService<Subscribe> _subscribeService;
        private readonly IMapper _mapper;

        public SubscribeController(IGenericService<Subscribe> subscribeService, IMapper mapper)
        {
            _subscribeService = subscribeService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSubscribers()
        {
            var subscribers= _subscribeService.TGetList();
            return Ok(subscribers);
        }

        [HttpPost]
        public IActionResult PostSubscribers(CreateSubscribeDto createSubscribeDto)
        {
            var newSubscribe= _mapper.Map<Subscribe>(createSubscribeDto);
            _subscribeService.TInsert(newSubscribe);
            return Ok(newSubscribe);
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribeById(int id)
        {
            var subscribe = _subscribeService.TGetById(id);
            return Ok(subscribe);
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(UpdateSubscribeDto updateSubscribeDto)
        {
            var subscribe= _mapper.Map<Subscribe>(updateSubscribeDto);
            _subscribeService.TUpdate(subscribe);
            return Ok(subscribe);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            _subscribeService.TDelete(id);
            return Ok("Abone başarıyla silindi.");
        }
    }
}
