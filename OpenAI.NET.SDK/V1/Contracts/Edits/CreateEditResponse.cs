using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Edits;

public class CreateEditResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("choices")]
    public List<EditChoice> Choices { get; set; } = new();

    [JsonPropertyName("usage")]
    public EditUsage Usage { get; set; } = null!;
}
