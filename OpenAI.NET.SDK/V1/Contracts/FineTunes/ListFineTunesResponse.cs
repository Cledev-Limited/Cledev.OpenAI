using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.FineTunes;

public record ListFineTunesResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("data")]
    public List<FineTuneResponse> Data { get; set; } = new();
}
