using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Files;

public record ListFilesResponse
{
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("data")]
    public List<FileResponse> Data { get; set; } = null!;
}
