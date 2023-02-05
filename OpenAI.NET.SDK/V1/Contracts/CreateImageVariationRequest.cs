using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts;

public class CreateImageVariationRequest
{
    [JsonPropertyName("image")]
    public required string Image { get; set; }

    [JsonPropertyName("n")]
    public required int? NumberOfImagesToGenerate { get; set; }

    [JsonPropertyName("size")]
    public required string? ImageSize { get; set; }

    [JsonPropertyName("response_format")]
    public required string? ResponseFormat { get; set; }

    [JsonPropertyName("user")]
    public string? User { get; set; }
}
