using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Edits;

public class EditUsage
{
    [JsonPropertyName("prompt_tokens")]
    public int PromptTokens { get; set; }

    [JsonPropertyName("completion_tokens")]
    public int EditTokens { get; set; }

    [JsonPropertyName("total_tokens")]
    public int TotalTokens { get; set; }
}
