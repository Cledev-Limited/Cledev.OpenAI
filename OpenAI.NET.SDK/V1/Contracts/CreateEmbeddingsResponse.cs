using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts;

public class CreateEmbeddingsResponse
{
    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("data")]
    public List<CreateEmbeddingsResponseData> Data { get; set; } = new();

    [JsonPropertyName("usage")]
    public CreateEmbeddingsResponseUsage Usage { get; set; } = null!;

    public record CreateEmbeddingsResponseData
    {
        [JsonPropertyName("object")]
        public string? Object { get; set; }

        [JsonPropertyName("index")] 
        public int? Index { get; set; }

        [JsonPropertyName("embedding")] 
        public List<double> Embedding { get; set; } = new();
    }

    public class CreateEmbeddingsResponseUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
