using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Embeddings;

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

    [JsonPropertyName("error")]
    public Error? Error { get; set; }
}
