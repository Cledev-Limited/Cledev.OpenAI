using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Files;

public record ListFilesResponse
{
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("data")]
    public List<FileResponse> Data { get; set; } = null!;

    [JsonPropertyName("error")]
    public Error? Error { get; set; }
}
