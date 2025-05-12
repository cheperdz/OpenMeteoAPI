using DTO.Input;
using DTO.Output;
using EFC.Context;
using EFC.Repositories.Interfaces;
using Patterns.Result;
using Patterns.Result.Errors;
using Services.Interfaces;
namespace EFC.Repositories;

public class WeatherRepository(WeatherDbContext context, IOpenMeteoService openMeteoService) : IWeatherRepository
{
    public async Task<Result<GetWeatherByLocationOutputDto>> GetWeatherByLocation(GetWeatherByLocationInputDto input)
    {
        var response = new GetWeatherByLocationOutputDto();

        if (input.Latitude is > 90 or < -90)
            return GetWeatherByLocationErrors.BadRequestLatitude;

        if (input.Longitude is > 180 or < -180)
            return GetWeatherByLocationErrors.BadRequestLongitude;

        // First we fetch from MongoDb
        var dbWeather = context.Weathers.FirstOrDefault(w => w.Longitude == input.Longitude && w.Latitude == input.Latitude && w.CreatedAt.Day == DateTime.UtcNow.Day);
        if (dbWeather != null)
            response = new GetWeatherByLocationOutputDto()
            {
                Temperature = dbWeather.Temperature,
                WindDirection = dbWeather.WindDirection,
                WindSpeed = dbWeather.WindSpeed,
                SunriseDateTimeIso8601 = dbWeather.Sunrise,
            };

        // If there is no register on the same Longitude and Latitude within the last day, we use the API
        else
        {
            var weather = await openMeteoService.GetWeatherDataAsync(input.Latitude, input.Longitude);

            await context.Weathers.AddAsync(weather);
            await context.SaveChangesAsync();

            response = new GetWeatherByLocationOutputDto()
            {
                Temperature = weather.Temperature,
                WindDirection = weather.WindDirection,
                WindSpeed = weather.WindSpeed,
                SunriseDateTimeIso8601 = weather.Sunrise,
            };

        }

        return response;
    }

    public Task<Result<GetWeatherByCityOutputDto>> GetWeatherByCity(GetWeatherByCityInputDto input) => null;
}
