using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Business.Abstract;
using TeaShop.Dto.Dtos.FaqDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FaqController : ControllerBase
    {
        private readonly IGenericService<Faq> _faqService;
        private readonly IMapper _mapper;

        public FaqController(IGenericService<Faq> faqService, IMapper mapper)
        {
            _faqService = faqService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetFaq()
        {
            var values = _faqService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddFaq(CreateFaqDto faqdto)
        {
            var newFaq = _mapper.Map<Faq>(faqdto);
            _faqService.TInsert(newFaq);
            return Ok("Soru Başarılı bir şekilde eklendi");
        }

        [HttpGet("{id}")]
        public IActionResult GetFaqById(int id)
        {
           var value = _faqService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateFaq(UpdateFaqDto faqDto)
        {
            var updateFaq = _mapper.Map<Faq>(faqDto);
            _faqService.TUpdate(updateFaq);
            return Ok(updateFaq);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFaq(int id)
        {
            _faqService.TDelete(id);
            return Ok("Soru başarılı bir şekilde silindi.");
        }

    }
}
