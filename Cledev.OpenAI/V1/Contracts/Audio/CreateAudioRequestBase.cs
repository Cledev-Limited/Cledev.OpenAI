namespace Cledev.OpenAI.V1.Contracts.Audio;

/// <summary>
/// Create audio request base.
/// </summary>
public abstract class CreateAudioRequestBase
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>The audio file to transcribe, in one of these formats: mp3, mp4, mpeg, mpga, m4a, wav, or webm.</para>
    /// </summary>
    public byte[] File { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>The name of the audio file to transcribe.</para>
    /// </summary>
    public string FileName { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>ID of the model to use. Only whisper-1 is currently available.</para>
    /// </summary>
    public string Model { get; set; } = null!;

    /// <summary>
    /// <para>Optional.</para>
    /// <para>An optional text to guide the model's style or continue a previous audio segment. The prompt should match the audio language.</para>
    /// </summary>
    public string? Prompt { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to json).</para>
    /// <para>The format of the transcript output, in one of these options: json, text, srt, verbose_json, or vtt.</para>
    /// </summary>
    public string? ResponseFormat { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 0).</para>
    /// <para>The sampling temperature, between 0 and 1. Higher values like 0.8 will make the output more random, while lower values like 0.2 will make it more focused and deterministic. If set to 0, the model will use log probability to automatically increase the temperature until certain thresholds are hit.</para>
    /// </summary>
    public float? Temperature { get; set; }
}
