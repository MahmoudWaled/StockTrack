using AutoMapper;
using StockTrack.Data.Entities;
using StockTrack.Services.DTOs;

namespace StockTrack.Services.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Entity ↔ DTO Mapping
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Sale, SaleDto>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ReverseMap();




        }
    }
}
