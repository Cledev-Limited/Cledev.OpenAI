using Cledev.OpenAI.V1.Contracts.Images;
using Cledev.OpenAI.V1.Models;
using Microsoft.AspNetCore.Components.Forms;
using Cledev.OpenAI.V1.Contracts;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class CreateImageEditPage : ImagePageBase
{
    protected CreateImageEditRequest Request { get; set; } = null!;

    protected override void OnInitialized()
    {
        Request = new CreateImageEditRequest
        {
            Image = new byte[1],
            ImageName = "Something",
            Prompt = string.Empty,
            Size = ImageSize.Size512x512.ToStringSize(),
            ResponseFormat = ImageFormat.B64Json.ToStringFormat()
        };

        Sizes = Enum.GetValues(typeof(ImageSize)).Cast<ImageSize>().Select(x => x.ToStringSize()).ToList();
        Formats = Enum.GetValues(typeof(ImageFormat)).Cast<ImageFormat>().Select(x => x.ToStringFormat()).ToList();
    }

    public async Task OnInputFileForImageChange(InputFileChangeEventArgs e)
    {
        Request.Image = await GetFileBytes(e);
        Request.ImageName = e.File.Name;
    }

    public async Task OnInputFileForMaskChange(InputFileChangeEventArgs e)
    {
        Request.Mask = await GetFileBytes(e);
        Request.MaskName = e.File.Name;
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

        Response = await OpenAIClient.CreateImageEdit(Request);
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
