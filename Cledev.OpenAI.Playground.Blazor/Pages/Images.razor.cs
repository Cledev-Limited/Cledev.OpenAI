using Cledev.OpenAI.V1.Contracts.Images;
using Cledev.OpenAI.V1.Models;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class ImagesPage : PageComponentBase
{
    protected CreateImageRequest Request { get; set; } = null!;
    protected CreateImageResponse? Response { get; set; }

    public IList<string> Sizes { get; set; } = new List<string>();
    public IList<string> Formats { get; set; } = new List<string>();


    public IList<string> Images { get; set; } = new List<string>();

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

    private static string Base64ToImage(string base64String)
    {
        var imageName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        var imagePath = $"images/{imageName}.jpg";
        using var imageFile = new FileStream($"wwwroot/{imagePath}", FileMode.Create);

        var bytes = Convert.FromBase64String(base64String);
        imageFile.Write(bytes, 0, bytes.Length);
        imageFile.Flush();

        return imagePath;
    }
}
