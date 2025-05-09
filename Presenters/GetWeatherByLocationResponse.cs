using DTO.Output;
using Patterns.Presenter;
using Patterns.Result;
using Ports.Output;

namespace Presenters;

public class GetWeatherByLocationResponse : IGetWeatherByLocationOutputPort, IPresenter<Result<GetWeatherByLocationOutputDto>>
{
    public Result<GetWeatherByLocationOutputDto> Content { get; private set; }

    public void Handle(Result<GetWeatherByLocationOutputDto> output) => Content = output;
}
