namespace DTO.Output;

public class GetWeatherByLocationOutputDto
{
    public double Temperature { get; init; }
    public double WindDirection { get; init; }
    public double WindSpeed { get; init; }
    public DateTime SunriseDateTimeIso8601 { get; init; }
}
