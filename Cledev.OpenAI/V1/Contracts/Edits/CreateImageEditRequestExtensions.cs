using Cledev.OpenAI.V1.Contracts.Images;

namespace Cledev.OpenAI.V1.Contracts.Edits;

internal static class CreateImageEditRequestExtensions
{
    internal static MultipartFormDataContent ToMultipartFormDataContent(this CreateImageEditRequest request)
    {
        var multipartContent = new MultipartFormDataContent
        {
            { new ByteArrayContent(request.Image), "image", request.ImageName },
            { new StringContent(request.Prompt), "prompt" }
        };

        if (request.Mask is not null && request.MaskName is not null)
        {
            multipartContent.Add(new ByteArrayContent(request.Mask), "mask", request.MaskName);
        }

        if (request.N is not null)
        {
            multipartContent.Add(new StringContent(request.N.ToString()!), "n");
        }

        if (request.Size is not null)
        {
            multipartContent.Add(new StringContent(request.Size), "size");
        }

        if (request.ResponseFormat is not null)
        {
            multipartContent.Add(new StringContent(request.ResponseFormat), "response_format");
        }

        if (request.User is not null)
        {
            multipartContent.Add(new StringContent(request.User), "user");
        }

        return multipartContent;
    }
}
