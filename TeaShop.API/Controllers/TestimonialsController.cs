using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Business.Abstract;
using TeaShop.Dto.Dtos.TestimonialDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IGenericService<Testimonial> _testimonialService;
        private readonly IMapper _mapper;

        public TestimonialsController(IGenericService<Testimonial> testimonialService, IMapper mapper)
        {
            _testimonialService = testimonialService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTestimonials()
        {
            var values = _testimonialService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonialById(int id)
        {
            var testimonial = _testimonialService.TGetById(id);
            return Ok(testimonial);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            _testimonialService.TDelete(id);
            return Ok("Referans başarıyla silindi.");
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDto createTestimonialDto)
        {
            var newTestimonial = _mapper.Map<Testimonial>(createTestimonialDto);
            _testimonialService.TInsert(newTestimonial);
            return Ok(newTestimonial);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            var updateTestimonial = _mapper.Map<Testimonial>(updateTestimonialDto);
            _testimonialService.TUpdate(updateTestimonial);
            return Ok(updateTestimonial);
        }
    }
}
