using DTO.Input;
using DTO.Output;
using Patterns.Result;

namespace EFC.Repositories.Interfaces;

public interface IWeatherRepository
{
    Task<Result<GetWeatherByLocationOutputDto>> GetWeatherByLocation(GetWeatherByLocationInputDto input);
    Task<Result<GetWeatherByCityOutputDto>> GetWeatherByCity(GetWeatherByCityInputDto input);
}
