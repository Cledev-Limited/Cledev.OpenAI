namespace Cledev.OpenAI.V1.Contracts.Audio;

internal static class CreateAudioTranscriptionRequestExtensions
{
    internal static MultipartFormDataContent ToMultipartFormDataContent(this CreateAudioTranscriptionRequest request)
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

        if (request.Language is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.Language!), "language");
        }

        return multipartFormDataContent;
    }
}
