using AutoMapper;
using MyHealthMap.Model;

namespace MyHealthMap.Data.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Restaurant, CreateRestaurantDto>().ReverseMap();
            CreateMap<Restaurant, GetRestaurantDto>().ReverseMap();
            CreateMap<Restaurant, UpdateRestaurantDto>().ReverseMap();
        }

    }
}
