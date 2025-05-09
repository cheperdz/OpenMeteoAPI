using DTO.Input;
using DTO.Output;
using EFC.Context;
using EFC.Repositories.Interfaces;
using Entities;
using Patterns.Result;

namespace EFC.Repositories;

public class WeatherRepository(WeatherTemplateDbContext context) : IWeatherRepository
{
    private readonly WeatherTemplateDbContext _context = context;

    public Task<Result<GetWeatherByLocationOutputDto>> GetWeatherByLocation(GetWeatherByLocationInputDto input) => throw new NotImplementedException();

    public Task<Result<GetWeatherByCityOutputDto>> GetWeatherByCity(GetWeatherByCityInputDto input) => throw new NotImplementedException();
}
