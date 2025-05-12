using AutoMapper;
using Entities;

namespace Mappings;

public class WeatherProfile : Profile
{
    /// <summary>
    /// Automapper class for Json Deserialization (see Services)
    /// </summary>
    public WeatherProfile()
    {
        CreateMap<OpenMeteoResponse, Weather>()
            .ForMember(dest => dest.Longitude, opt => opt
                .MapFrom(src => src.Longitude))
            .ForMember(dest => dest.Latitude, opt => opt
                .MapFrom(src => src.Latitude))
            .ForMember(dest => dest.WindDirection, opt => opt
                .MapFrom(src => src.Current.WindDirection))
            .ForMember(dest => dest.Temperature, opt => opt
                .MapFrom(src => src.Current.Temperature))
            .ForMember(dest => dest.WindSpeed, opt => opt
                .MapFrom(src => src.Current.WindSpeed))
            .ForMember(dest => dest.CreatedAt, opt => opt
                .MapFrom(src => DateTime.UtcNow))
            .ForMember(dest => dest.Sunrise, opt => opt
                .MapFrom(src => src.Daily.Sunrise[0]));
    }
}
