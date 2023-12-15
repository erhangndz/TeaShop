using AutoMapper;
using TeaShop.Presentation.Dtos.AboutDtos;
using TeaShop.Presentation.Dtos.DrinkDtos;
using TeaShop.Presentation.Dtos.FaqDtos;
using TeaShop.Presentation.Dtos.MessageDtos;
using TeaShop.Presentation.Dtos.SubscribeDtos;
using TeaShop.Presentation.Dtos.TestimonialDtos;
using TeaShop.Entity.Models;
using TeaShop.Presentation.Models;

namespace TeaShop.Presentation.Mapping
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

            CreateMap<RegisterViewModel, AppUser>().ReverseMap();
            CreateMap<LoginViewModel, AppUser>().ReverseMap();


        }
    }
}
