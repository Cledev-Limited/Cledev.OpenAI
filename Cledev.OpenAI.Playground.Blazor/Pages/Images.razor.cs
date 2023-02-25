using Cledev.OpenAI.V1.Contracts.Images;
using Cledev.OpenAI.V1.Models;
using Microsoft.AspNetCore.Components;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class ImagesPage : PageComponentBase
{
    [Inject] public WebClient WebClient { get; set; } = null!;

    protected CreateImageRequest Request { get; set; } = null!;
    protected CreateImageResponse? Response { get; set; }

    public IList<string> Sizes { get; set; } = new List<string>();
    public IList<string> Formats { get; set; } = new List<string>();

    protected override void OnInitialized()
    {
        Request = new CreateImageRequest
        {
            Prompt = string.Empty,
            Size = ImageSize.Size512x512.ToStringSize(),
            ResponseFormat = ImageFormat.Url.ToStringFormat()
        };

        Sizes = Enum.GetValues(typeof(ImageSize)).Cast<ImageSize>().Select(x => x.ToStringSize()).ToList();
        Formats = Enum.GetValues(typeof(ImageFormat)).Cast<ImageFormat>().Select(x => x.ToStringFormat()).ToList();
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;

        Response = null;
        Error = null;

        Response = await OpenAIClient.CreateImage(Request);
        Error = Response?.Error;

        IsLoading = false;
    }
}
