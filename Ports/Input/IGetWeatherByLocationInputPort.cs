using DTO.Input;

namespace Ports.Input;

public interface IGetWeatherByLocationInputPort
{
    Task Handle(GetWeatherByLocationInputDto input);
}
