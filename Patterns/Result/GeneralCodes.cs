namespace Patterns.Result;

public static class GeneralCodes
{
    // 400's
    public static readonly Code BadRequest = new (400, "Input is not valid");
    public static readonly Code NotFound = new (404, "Id not found");

    // 500's
    public static readonly Code InternalServerCode = new (500, "Internal server error"); // public static Error IntrernalServerError(string dbContextName) => new (500, "Error saving changes in database on context: " + dbContextName);
    public static readonly Code HttpServiceError = new(500, "Error while using a internal HTTP service");
    public static readonly Code JsonDeserializationError = new(500, "Error while deserializing a JSON file");
    public static readonly Code AutoMappingError = new(500, "Error while trying to AutoMap");


    // public static Error UnhandledError(string exceptionMessage, string innerExceptionMessage = "") => new (-1, exceptionMessage + " \n INNER EXCEPTION:" + string.IsNullOrEmpty(innerExceptionMessage ?? "None"));
}
