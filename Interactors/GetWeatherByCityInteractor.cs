using DTO.Input;
using EFC.Repositories.Interfaces;
using Ports.Input;
using Ports.Output;

namespace Interactors;

public class GetWeatherByCityInteractor(IWeatherRepository weatherRepository, IGetWeatherByCityOutputPort getWeatherByCityOutputPort) : IGetWeatherByCityInputPort
{
    public async Task Handle(GetWeatherByCityInputDto input)
    {
        try
        {
            var result = await weatherRepository.GetWeatherByCity(input);
            getWeatherByCityOutputPort.Handle(result);
        }

        catch (Exception ex)
        {
            Console.WriteLine("Excepción no controlada en el interactor GetWeatherByCity: " + ex.Message); // TODO: Pasar a SeriLog

            if(ex.InnerException != null)
                Console.WriteLine("Inner Ex: " + ex.InnerException);

            throw;
        }
    }
}
