using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Completions;

public record CreateCompletionResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("choices")]
    public List<CompletionChoice> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public CompletionUsage? Usage { get; set; } = null!;
}
