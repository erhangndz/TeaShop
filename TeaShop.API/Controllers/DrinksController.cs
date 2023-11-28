using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.Business.Abstract;
using TeaShop.Dto.Dtos.DrinkDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IGenericService<Drink> _drinkService;
        private readonly IMapper _mapper;

        public DrinksController(IGenericService<Drink> drinkService, IMapper mapper)
        {
            _drinkService = drinkService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetDrinks()
        {
            var values = _drinkService.TGetList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddDrink(CreateDrinkDto drinkDto)
        {
            var newDrink= _mapper.Map<Drink>(drinkDto);
           _drinkService.TInsert(newDrink);
            return Ok(newDrink);
        }

        [HttpDelete]
        public IActionResult DeleteDrink(int id)
        {
            _drinkService.TDelete(id);
            return Ok("İçecek başarılı bir şekilde silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDrinkById(int id)
        {
            var value = _drinkService.TGetById(id);
            return Ok(value);
        }

        [HttpPut]
        public IActionResult UpdateDrink(UpdateDrinkDto drinkDto)
        {
            var updateDrink = _mapper.Map<Drink>(drinkDto);
            _drinkService.TUpdate(updateDrink);
            return Ok(updateDrink);
        }

    }
}
