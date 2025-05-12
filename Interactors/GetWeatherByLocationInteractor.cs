using DTO.Input;
using EFC.Repositories.Interfaces;
using Services.Interfaces;
using Ports.Input;
using Ports.Output;

namespace Interactors;

public class GetWeatherByLocationInteractor(IWeatherRepository weatherRepository, IOpenMeteoService openMeteoService, IGetWeatherByLocationOutputPort getWeatherByLocationOutputPort) : IGetWeatherByLocationInputPort
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
            Console.WriteLine("Excepción no controlada en el interactor GetWeatherByLocation: " + ex.Message); // TODO: Pasar a SeriLog

            if(ex.InnerException != null)
                Console.WriteLine("Inner Ex: " + ex.InnerException);

            throw;
        }
    }
}
