namespace OpenAI.NET.SDK.Models;

public record Failure(string ErrorCode = ErrorCodes.Error, string? Title = null, string? Description = null);
