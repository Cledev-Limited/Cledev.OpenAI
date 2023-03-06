namespace Cledev.OpenAI.V1.Helpers;

public enum AudioResponseFormat
{
    Json,
    Text,
    Srt,
    VerboseJson,
    Vtt
}

public static class AudioHelpersExtensions
{
    public static string ToStringFormat(this AudioResponseFormat audioResponseFormat)
    {
        return audioResponseFormat switch
        {
            AudioResponseFormat.Json => "json",
            AudioResponseFormat.Text => "text",
            AudioResponseFormat.Srt => "srt",
            AudioResponseFormat.VerboseJson => "verbose_json",
            AudioResponseFormat.Vtt => "vtt",
            _ => throw new ArgumentOutOfRangeException(nameof(audioResponseFormat), audioResponseFormat, null)
        };
    }
}
