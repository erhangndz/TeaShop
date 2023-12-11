using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Business.Abstract;
using TeaShop.Dto.Dtos.MessageDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IGenericService<Message> _messageService;
        private readonly IMapper _mapper;

        public MessageController(IGenericService<Message> messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetMessage()
        {
            var values = _messageService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddMessage(CreateMessageDto createMessageDto)
        {
            var newMessage = _mapper.Map<Message>(createMessageDto);
            _messageService.TInsert(newMessage);
            return Ok("Mesaj Başarılı bir şekilde eklendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessageById(int id)
        {
            var value = _messageService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var updateMessage = _mapper.Map<Message>(updateMessageDto);
            _messageService.TUpdate(updateMessage);
            return Ok(updateMessage);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            _messageService.TDelete(id);
            return Ok("Mesaj başarılı bir şekilde silindi.");
        }
    }
}
