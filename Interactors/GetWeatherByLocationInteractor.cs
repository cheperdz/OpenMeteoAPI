using DTO.Input;
using EFC.Repositories.Interfaces;
using Ports.Input;
using Ports.Output;

namespace Interactors;

public class GetWeatherByLocationInteractor(IWeatherRepository weatherRepository, IGetWeatherByLocationOutputPort getWeatherByLocationOutputPort) : IGetWeatherByLocationInputPort
{
    public async Task Handle(GetWeatherByLocationInputDto input)
    {
        try
        {
            var result = await weatherRepository.GetWeatherByLocation(input);
            getWeatherByLocationOutputPort.Handle(result);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Excepción en CreateBloqueTimespanInteractor: " + ex.Message);
            throw;
        }
    }
}
