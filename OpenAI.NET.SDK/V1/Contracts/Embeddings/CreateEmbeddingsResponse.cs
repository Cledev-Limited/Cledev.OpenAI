using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Embeddings;

public record CreateEmbeddingsResponse
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("data")]
    public List<EmbeddingsData> Data { get; set; } = new();

    [JsonPropertyName("usage")]
    public EmbeddingsUsage Usage { get; set; } = null!;
}
