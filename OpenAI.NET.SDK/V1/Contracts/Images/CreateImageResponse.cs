using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Images;

public record CreateImageResponse
{
    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("data")]
    public List<CreateImageResponseData> Data { get; set; } = new();

    public record CreateImageResponseData
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("b64_json")]
        public string? B64Json { get; set; }
    }
}
