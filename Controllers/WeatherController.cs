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

    IGetWeatherByCityInputPort createWeatherByCityInputPort,
    IGetWeatherByCityOutputPort createWeatherByCityOutputPort
)
{
    [HttpGet("getWeather")]
    public async Task<Result<GetWeatherByLocationOutputDto>> GetWeather([FromQuery] GetWeatherByLocationInputDto input)
    {
        await getWeatherByLocationInputPort.Handle(input);
        return ((IPresenter<Result<GetWeatherByLocationOutputDto>>)getWeatherByLocationOutputPort).Content;
    }
}
