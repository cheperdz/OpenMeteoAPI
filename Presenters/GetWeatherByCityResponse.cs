using DTO.Output;
using Patterns.Presenter;
using Patterns.Result;
using Ports.Output;

namespace Presenters;

public class GetWeatherByCityResponse : IGetWeatherByCityOutputPort, IPresenter<Result<GetWeatherByCityOutputDto>>
{
    public Result<GetWeatherByCityOutputDto> Content { get; private set; }

    public void Handle(Result<GetWeatherByCityOutputDto> output) => Content = output;
}
