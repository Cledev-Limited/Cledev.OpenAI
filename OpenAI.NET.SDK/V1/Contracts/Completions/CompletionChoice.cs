using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Completions;

public record CompletionChoice
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("logprobs")]
    public string? Logprobs { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; } = null!;
}
