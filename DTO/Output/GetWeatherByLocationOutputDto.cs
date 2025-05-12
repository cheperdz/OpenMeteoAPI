namespace DTO.Output;

public class GetWeatherByLocationOutputDto
{
    public double Temperature { get; init; }
    public int WindDirection { get; init; }
    public int WindSpeed { get; init; }
    public DateTime SunriseDateTimeIso8601 { get; init; }
}
