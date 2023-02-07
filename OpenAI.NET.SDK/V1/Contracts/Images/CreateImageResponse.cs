using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Images;

public class CreateImageResponse
{
    [JsonPropertyName("created")]
    public int Created { get; set; }

    [JsonPropertyName("data")]
    public List<CreateImageResponseData> Data { get; set; } = new();

    public class CreateImageResponseData
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("b64_json")]
        public string? B64Json { get; set; }
    }
}
