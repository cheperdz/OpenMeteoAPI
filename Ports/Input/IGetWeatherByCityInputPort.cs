using DTO.Input;

namespace Ports.Input;

public interface IGetWeatherByCityInputPort
{
    Task Handle(GetWeatherByCityInputDto input);
}
