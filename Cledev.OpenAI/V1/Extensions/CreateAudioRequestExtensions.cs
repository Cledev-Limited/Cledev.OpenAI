using Cledev.OpenAI.V1.Contracts.Audio;
using Cledev.OpenAI.V1.Helpers;

namespace Cledev.OpenAI.V1.Extensions;

internal static class CreateAudioRequestExtensions
{
    internal static MultipartFormDataContent ToMultipartFormDataContent(this CreateAudioRequestBase request)
    {
        var multipartFormDataContent = new MultipartFormDataContent
        {
            { new ByteArrayContent(request.File), "file", request.FileName },
            { new StringContent(request.Model), "model" }
        };

        if (request.Prompt is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.Prompt), "prompt");
        }

        if (request.ResponseFormat is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.ResponseFormat), "response_format");
        }

        if (request.Temperature is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.Temperature.ToString()!), "temperature");
        }

        return multipartFormDataContent;
    }

    public static bool HasJsonResponseFormat(this CreateAudioRequestBase request)
    {
        return request.ResponseFormat == AudioResponseFormat.Json ||
               request.ResponseFormat == AudioResponseFormat.VerboseJson;
    }
}
