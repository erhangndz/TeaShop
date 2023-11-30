using AutoMapper;
using TeaShop.Dto.Dtos.DrinkDtos;
using TeaShop.Dto.Dtos.FaqDtos;
using TeaShop.Entity.Models;

namespace TeaShop.API.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<CreateFaqDto,Faq>().ReverseMap();
            CreateMap<UpdateFaqDto,Faq>().ReverseMap();
            CreateMap<CreateDrinkDto,Drink>().ReverseMap();
            CreateMap<UpdateDrinkDto,Drink>().ReverseMap();
            
        }
    }
}
