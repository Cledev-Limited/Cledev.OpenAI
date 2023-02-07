using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Models;

public class ListModelsResponse
{
    [JsonPropertyName("data")]
    public List<ListModelsResponseData> Data { get; set; } = null!;

    public class ListModelsResponseData
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("owned_by")]
        public string OwnedBy { get; set; } = null!;

        [JsonPropertyName("permissions")]
        public List<ListModelsResponseDataPermission> Permissions { get; set; } = null!;

        public class ListModelsResponseDataPermission
        {
            [JsonPropertyName("id")]
            public string Id { get; set; } = null!;
        }
    }
}
