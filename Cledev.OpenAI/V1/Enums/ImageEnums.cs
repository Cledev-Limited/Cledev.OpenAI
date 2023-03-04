﻿namespace Cledev.OpenAI.V1.Enums;

public enum ImageSize
{
    Size256x256,
    Size512x512,
    Size1024x1024
}

public enum ImageResponseFormat
{
    Url,
    B64Json
}

public static class ImageEnumsExtensions
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
            ImageResponseFormat.B64Json => "b64_json",
            _ => throw new ArgumentOutOfRangeException(nameof(imageResponseFormat), imageResponseFormat, null)
        };
    }
}
