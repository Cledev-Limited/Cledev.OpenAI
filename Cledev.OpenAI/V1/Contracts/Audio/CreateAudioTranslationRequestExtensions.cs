namespace Cledev.OpenAI.V1.Contracts.Audio;

internal static class CreateAudioTranslationRequestExtensions
{
    internal static MultipartFormDataContent ToMultipartFormDataContent(this CreateAudioTranslationRequest request)
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
}
