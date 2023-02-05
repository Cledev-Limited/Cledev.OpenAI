namespace OpenAI.SDK.Results;

public record Failure(string ErrorCode = ErrorCodes.Error, string? Title = null, string? Description = null);

public static class FailureExtensions
{
    public static Failure WithTitle(this Failure failure, string title) => 
        failure with { Title = title };

    public static Failure WithDescription(this Failure failure, string description) => 
        failure with { Description = description };

    public static Failure WithDescription(this Failure failure, string description, IEnumerable<string> items) => 
        failure with { Description = $"{description}: {string.Join(", ", items)}" };
}

public static class ErrorCodes
{
    public const string Error = "Error";
    public const string NotFound = "NotFound";
    public const string Unauthorized = "Unauthorized";
}
