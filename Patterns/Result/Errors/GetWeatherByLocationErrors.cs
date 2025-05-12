namespace Patterns.Result.Errors;

public static class GetWeatherByLocationErrors
{
    public static readonly Code BadRequestLatitude = new (400, "Latitude must be between 90° and -90°");
    public static readonly Code BadRequestLongitude = new(400, "Longitude must be between 180° and -180°");
}
