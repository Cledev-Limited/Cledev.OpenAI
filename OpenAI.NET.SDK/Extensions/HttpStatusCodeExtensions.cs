using System.Net;
using OpenAI.NET.SDK.Models;

namespace OpenAI.NET.SDK.Extensions;

internal static class HttpStatusCodeExtensions
{
    internal static string ToErrorCode(this HttpStatusCode httpStatusCode)
    {
        return httpStatusCode switch
        {
            HttpStatusCode.Unauthorized => ErrorCodes.Unauthorized,
            HttpStatusCode.BadRequest => ErrorCodes.BadRequest,
            HttpStatusCode.NotFound => ErrorCodes.NotFound,
            _ => ErrorCodes.Error
        };
    }
}
