using System.Text.Json.Serialization;

namespace OpenAI.SDK.V1.Contracts;

public class CreateCompletionRequest
{
    [JsonPropertyName("model")]
    public required string Model { get; set; }

    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; }

    [JsonPropertyName("temperature")]
    public int? Temperature { get; set; }

    [JsonPropertyName("top_p")]
    public int? TopP { get; set; }

    [JsonPropertyName("n")]
    public int? N { get; set; }

    [JsonPropertyName("stream")]
    public bool? Stream { get; set; }

    [JsonPropertyName("logprobs")]
    public int? Logprobs { get; set; }

    [JsonPropertyName("stop")]
    public string? Stop { get; set; }
}
