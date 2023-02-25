using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Edits;

public record CreateEditResponse : ResponseBase
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
