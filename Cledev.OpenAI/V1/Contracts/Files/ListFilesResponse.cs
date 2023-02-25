using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Files;

public record ListFilesResponse : ResponseBase
{
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("data")]
    public List<FileResponse> Data { get; set; } = null!;
}
