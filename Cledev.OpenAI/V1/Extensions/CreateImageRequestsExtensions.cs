using Cledev.OpenAI.V1.Contracts.Images;

namespace Cledev.OpenAI.V1.Extensions;

internal static class CreateImageRequestsExtensions
{
    internal static MultipartFormDataContent ToMultipartFormDataContent(this CreateImageEditRequest request)
    {
        var multipartFormDataContent = new MultipartFormDataContent
        {
            { new ByteArrayContent(request.Image), "image", request.ImageName },
            { new StringContent(request.Prompt), "prompt" }
        };

        if (request.Mask is not null && request.MaskName is not null)
        {
            multipartFormDataContent.Add(new ByteArrayContent(request.Mask), "mask", request.MaskName);
        }

        multipartFormDataContent.AddOptionsFrom(request);

        return multipartFormDataContent;
    }

    internal static MultipartFormDataContent ToMultipartFormDataContent(this CreateImageVariationRequest request)
    {
        var multipartFormDataContent = new MultipartFormDataContent
        {
            { new ByteArrayContent(request.Image), "image", request.ImageName }
        };

        multipartFormDataContent.AddOptionsFrom(request);

        return multipartFormDataContent;
    }

    private static void AddOptionsFrom(this MultipartFormDataContent multipartFormDataContent, CreateImageRequestBase request)
    {
        if (request.N is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.N.ToString()!), "n");
        }

        if (request.Size is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.Size), "size");
        }

        if (request.ResponseFormat is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.ResponseFormat), "response_format");
        }

        if (request.User is not null)
        {
            multipartFormDataContent.Add(new StringContent(request.User), "user");
        }
    }
}
