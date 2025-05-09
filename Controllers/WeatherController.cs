using DTO.Input;
using DTO.Output;
using Microsoft.AspNetCore.Mvc;
using Patterns.Presenter;
using Patterns.Result;
using Ports.Input;
using Ports.Output;

namespace Controllers;

[ApiController, Route("api/[controller]")]
public class WeatherController
(
    IGetWeatherByLocationInputPort getWeatherByLocationInputPort,
    IGetWeatherByLocationOutputPort getWeatherByLocationOutputPort,

    IGetWeatherByCityInputPort getWeatherByCityInputPort,
    IGetWeatherByCityOutputPort getWeatherByCityOutputPort
)
{
    [HttpGet("getWeatherByLocation")]
    public async Task<Result<GetWeatherByLocationOutputDto>> GetWeatherByLocation([FromQuery] GetWeatherByLocationInputDto input)
    {
        await getWeatherByLocationInputPort.Handle(input);
        return ((IPresenter<Result<GetWeatherByLocationOutputDto>>)getWeatherByLocationOutputPort).Content;
    }

    [HttpGet("getWeatherByCity")]
    public async Task<Result<GetWeatherByCityOutputDto>> GetWeatherByCity([FromQuery] GetWeatherByCityInputDto input)
    {
        await getWeatherByCityInputPort.Handle(input);
        return ((IPresenter<Result<GetWeatherByCityOutputDto>>)getWeatherByCityOutputPort).Content;
    }
}
