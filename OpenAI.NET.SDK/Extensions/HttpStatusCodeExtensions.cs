using System.Net;
using OpenAI.NET.SDK.Models;

namespace OpenAI.NET.SDK.Extensions;

internal static class HttpStatusCodeExtensions
{
    internal static string ToErrorCode(this HttpStatusCode httpStatusCode)
    {
        return httpStatusCode switch
        {
            HttpStatusCode.Unauthorized => Errors.Unauthorized,
            HttpStatusCode.BadRequest => Errors.BadRequest,
            HttpStatusCode.NotFound => Errors.NotFound,
            _ => Errors.Error
        };
    }
}
