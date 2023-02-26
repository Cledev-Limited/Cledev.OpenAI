using Cledev.OpenAI.V1.Contracts;
using Cledev.OpenAI.V1.Contracts.Images;
using Cledev.OpenAI.V1.Models;
using Microsoft.AspNetCore.Components.Forms;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class CreateImageVariationPage : ImagePageBase
{
    protected CreateImageVariationRequest Request { get; set; } = null!;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        Request = new CreateImageVariationRequest
        {
            Image = new byte[1],
            ImageName = "Something",
            Size = ImageSize.Size512x512.ToStringSize(),
            ResponseFormat = ImageFormat.B64Json.ToStringFormat(),
            N = 1
        };
    }

    public async Task OnInputFileForImageChange(InputFileChangeEventArgs e)
    {
        Request.Image = await GetFileBytes(e);
        Request.ImageName = e.File.Name;
    }

    private async Task<byte[]> GetFileBytes(InputFileChangeEventArgs e)
    {
        using var memoryStream = new MemoryStream();

        try
        {
            await e.File.OpenReadStream(maxAllowedSize: 4000000).CopyToAsync(memoryStream);
        }
        catch (Exception exception)
        {
            Error = new Error
            {
                Message = exception.Message
            };
        }

        return memoryStream.ToArray();
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;

        Response = null;
        Error = null;
        Images.Clear();

        Response = await OpenAIClient.CreateImageVariation(Request);
        Error = Response?.Error;

        if (Response is not null)
        {
            foreach (var image in Response.Data)
            {
                if (string.IsNullOrEmpty(image.Url) is false)
                {
                    Images.Add(image.Url);
                }
                else if (string.IsNullOrEmpty(image.B64Json) is false)
                {
                    var imagePath = Base64ToImage(image.B64Json);
                    Images.Add(imagePath);
                }
            }
        }

        IsLoading = false;
    }
}
