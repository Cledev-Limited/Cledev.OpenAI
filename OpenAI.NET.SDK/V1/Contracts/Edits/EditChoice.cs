using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Edits;

public class EditChoice
{
    [JsonPropertyName("text")]
    public string Text { get; set; } = null!;

    [JsonPropertyName("index")]
    public int Index { get; set; }
}
