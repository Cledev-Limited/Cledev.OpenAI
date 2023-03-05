namespace Cledev.OpenAI.V1.Contracts.Audio;

/// <summary>
/// Transcribes audio into the input language.
/// </summary>
public class CreateAudioTranscriptionRequest : CreateAudioRequestBase
{
    /// <summary>
    /// <para>Optional.</para>
    /// <para>The language of the input audio. Supplying the input language in ISO-639-1 format will improve accuracy and latency.</para>
    /// </summary>
    public string? Language { get; set; }
}
