namespace DTO.Output;

public class GetWeatherByCityOutputDto
{
    public int Temperature { get; init; }
    public int WindDirection { get; init; }
    public int WindSpeed { get; init; }
    public DateTime SunriseDateTimeIso8601 { get; init; }
}
