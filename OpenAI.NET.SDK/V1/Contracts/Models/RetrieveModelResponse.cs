using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.Models;

public class RetrieveModelResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("owned_by")]
    public string OwnedBy { get; set; } = null!;

    [JsonPropertyName("permissions")]
    public List<RetrieveModelResponsePermission> Permissions { get; set; } = null!;

    public class RetrieveModelResponsePermission
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;
    }
}
