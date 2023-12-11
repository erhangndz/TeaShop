using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Business.Abstract;
using TeaShop.Dto.Dtos.AboutDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IGenericService<About> _aboutService;
        private readonly IMapper _mapper;

        public AboutController(IGenericService<About> aboutService, IMapper mapper)
        {
            _aboutService = aboutService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAbouts()
        {
            var values = _aboutService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult PostAbouts(CreateAboutDto createAboutDto)
        {
            var newAbout = _mapper.Map<About>(createAboutDto);
            _aboutService.TInsert(newAbout);
            return Ok(newAbout);
        }

        [HttpGet("{id}")]
        public IActionResult GetAboutById(int id)
        {
            var about = _aboutService.TGetById(id);
            return Ok(about);
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var updateAbout = _mapper.Map<About>(updateAboutDto);
            _aboutService.TUpdate(updateAbout);
            return Ok(updateAbout);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            _aboutService.TDelete(id);
            return Ok("Hakkımızda başarıyla silindi");
        }

    }
}
