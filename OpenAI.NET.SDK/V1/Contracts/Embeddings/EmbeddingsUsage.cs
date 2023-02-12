using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Embeddings;

public record EmbeddingsUsage
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}
