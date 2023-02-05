using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts;

public class CreateEditResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("choices")]
    public List<CreateEditResponseChoice> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public CreateEditResponseUsage Usage { get; set; } = null!;

    public class CreateEditResponseChoice
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = null!;

        [JsonPropertyName("index")]
        public int Index { get; set; }
    }

    public class CreateEditResponseUsage
    {
        [JsonPropertyName("prompt_tokens")]
        public int PromptTokens { get; set; }

        [JsonPropertyName("completion_tokens")]
        public int EditTokens { get; set; }

        [JsonPropertyName("total_tokens")]
        public int TotalTokens { get; set; }
    }
}
