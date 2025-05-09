using DTO.Output;
using Patterns.Result;

namespace Ports.Output;

public interface IGetWeatherByLocationOutputPort
{
    void Handle(Result<GetWeatherByLocationOutputDto> output);
}
