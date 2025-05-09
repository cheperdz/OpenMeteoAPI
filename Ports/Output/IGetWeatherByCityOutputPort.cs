using DTO.Output;
using Patterns.Result;

namespace Ports.Output;

public interface IGetWeatherByCityOutputPort
{
    void Handle(Result<GetWeatherByCityOutputDto> output);
}
