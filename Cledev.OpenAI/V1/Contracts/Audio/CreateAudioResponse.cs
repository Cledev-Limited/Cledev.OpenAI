using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Audio;

public record CreateAudioResponse : ResponseBase
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }
}
