using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Files;

public record FileResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("bytes")]
    public int? Bytes { get; set; }

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("filename")]
    public string FileName { get; set; } = null!;

    [JsonPropertyName("purpose")]
    public string Purpose { get; set; } = null!;

    [JsonPropertyName("error")]
    public Error? Error { get; set; }
}
