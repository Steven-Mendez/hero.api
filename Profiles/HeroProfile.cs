using AutoMapper;
using hero.api.Dtos;
using hero.api.Entities;

namespace hero.api.Profiles
{
    public class HeroProfile : Profile
    {
        public HeroProfile()
        {
            CreateMap<List<Hero>, HeroResponseDto>()
                .ForMember(dest => dest.Data, opt => opt.MapFrom(src => src));
            CreateMap<HeroRequestDto, Hero>().ReverseMap();
        }
    }
}
