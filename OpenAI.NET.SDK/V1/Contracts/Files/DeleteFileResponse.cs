using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Files;

public class DeleteFileResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }
}
