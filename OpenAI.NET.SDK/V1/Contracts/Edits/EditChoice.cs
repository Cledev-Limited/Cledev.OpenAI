using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Edits;

public class EditChoice
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [JsonPropertyName("index")]
    public int Index { get; set; }
}
