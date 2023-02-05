using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts;

public class RetrieveModelsResponse
{
    [JsonPropertyName("data")]
    public List<RetrieveModelsResponseData> Data { get; set; } = null!;

    public class RetrieveModelsResponseData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("owned_by")]
        public string OwnedBy { get; set; } = null!;

        [JsonPropertyName("permissions")]
        public List<RetrieveModelsResponseDataPermission> Permissions { get; set; } = null!;

        public class RetrieveModelsResponseDataPermission
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = null!;
        }
    }
}
