using AutoMapper;
using TeaShop.Dto.Dtos.AboutDtos;
using TeaShop.Dto.Dtos.DrinkDtos;
using TeaShop.Dto.Dtos.FaqDtos;
using TeaShop.Dto.Dtos.MessageDtos;
using TeaShop.Dto.Dtos.SubscribeDtos;
using TeaShop.Dto.Dtos.TestimonialDtos;
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

            CreateMap<CreateTestimonialDto,Testimonial>().ReverseMap();
            CreateMap<UpdateTestimonialDto,Testimonial>().ReverseMap();

            CreateMap<CreateAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();

            CreateMap<CreateMessageDto,Message>().ReverseMap();
            CreateMap<UpdateMessageDto,Message>().ReverseMap();

            CreateMap<CreateSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<UpdateSubscribeDto, Subscribe>().ReverseMap();


        }
    }
}
