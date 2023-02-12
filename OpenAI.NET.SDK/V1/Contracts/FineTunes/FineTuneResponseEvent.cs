using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.FineTunes;

public record FineTuneResponseEvent
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("level")]
    public string Level { get; set; } = null!;

    [JsonPropertyName("message")]
    public string Message { get; set; } = null!;
}
