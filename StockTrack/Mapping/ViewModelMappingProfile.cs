using AutoMapper;
using StockTrack.Services.DTOs;
using StockTrack.ViewModels;

namespace StockTrack.Mapping
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            // DTO ↔  ViewModel Mapping

            CreateMap<ProductDto, ProductVM>().ReverseMap();
            CreateMap<UserDto, UserVM>().ReverseMap();
            CreateMap<SaleDto, SaleVM>()
            .ForMember(dest => dest.Product, opt => opt.MapFrom(src => src.Product))
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Products, opt => opt.Ignore())
            .ForMember(dest => dest.Sellers, opt => opt.Ignore())
            .ReverseMap();
        }
    }
}
