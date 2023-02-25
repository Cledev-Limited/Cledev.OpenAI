using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts;

public record Error
{
    [JsonPropertyName("code")]
    public string? Code { get; set; }

    [JsonPropertyName("message")]
    public string? Message { get; set; }

    [JsonPropertyName("param")]
    public string? Param { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }
}
