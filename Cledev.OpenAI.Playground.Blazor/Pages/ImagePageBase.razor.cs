using Cledev.OpenAI.V1.Contracts.Images;
using Cledev.OpenAI.V1.Models;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public abstract class ImagePageBase : PageComponentBase
{
    protected CreateImageResponse? Response { get; set; }

    public IList<string> Sizes { get; set; } = new List<string>();
    public IList<string> Formats { get; set; } = new List<string>();

    public IList<string> Images { get; set; } = new List<string>();

    protected override void OnInitialized()
    {
        Sizes = Enum.GetValues(typeof(ImageSize)).Cast<ImageSize>().Select(x => x.ToStringSize()).ToList();
        Formats = Enum.GetValues(typeof(ImageFormat)).Cast<ImageFormat>().Select(x => x.ToStringFormat()).ToList();
    }

    protected static string Base64ToImage(string base64String)
    {
        var imageName = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds().ToString();
        var imagePath = $"images/{imageName}.png";
        using var imageFile = new FileStream($"wwwroot/{imagePath}", FileMode.Create);

        var bytes = Convert.FromBase64String(base64String);
        imageFile.Write(bytes, 0, bytes.Length);
        imageFile.Flush();

        return imagePath;
    }
}
