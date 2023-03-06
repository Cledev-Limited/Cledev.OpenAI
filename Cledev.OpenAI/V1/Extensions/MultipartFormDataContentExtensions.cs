using Cledev.OpenAI.V1.Contracts.Audio;

namespace Cledev.OpenAI.V1.Extensions;

internal static class MultipartFormDataContentExtensions
{
    internal static MultipartFormDataContent AddOtherOptionsFrom(this MultipartFormDataContent multipartFormDataContent, CreateAudioTranscriptionRequest request)
    {
        if (request.Language is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.Language!), "language");
        }

        return multipartFormDataContent;
    }
}
