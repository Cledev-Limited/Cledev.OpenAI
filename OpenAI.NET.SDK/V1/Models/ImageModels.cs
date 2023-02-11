namespace OpenAI.NET.SDK.V1.Models;

public enum ImageSize
{
    Size256x256,
    Size512x512,
    Size1024x1024
}

public enum ImageResponseFormat
{
    Url,
    Base64
}

public static class ImageModelsExtensions
{
    public static string ToStringSize(this ImageSize imageSize)
    {
        return imageSize switch
        {
            ImageSize.Size256x256 => "256x256",
            ImageSize.Size512x512 => "512x512",
            ImageSize.Size1024x1024 => "1024x1024",
            _ => throw new ArgumentOutOfRangeException(nameof(imageSize), imageSize, null)
        };
    }

    public static string ToStringFormat(this ImageResponseFormat imageResponseFormat)
    {
        return imageResponseFormat switch
        {
            ImageResponseFormat.Url => "url",
            ImageResponseFormat.Base64 => "b64_json",
            _ => throw new ArgumentOutOfRangeException(nameof(imageResponseFormat), imageResponseFormat, null)
        };
    }
}
