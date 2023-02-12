namespace OpenAI.NET.SDK.Models;

public record Error(string ErrorCode = ErrorCodes.Error, string? Title = null, string? Description = null);
