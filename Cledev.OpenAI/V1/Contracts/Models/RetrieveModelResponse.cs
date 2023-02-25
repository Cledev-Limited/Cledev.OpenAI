using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Models;

public record RetrieveModelResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("owned_by")]
    public string OwnedBy { get; set; } = null!;

    [JsonPropertyName("permissions")]
    public List<Permission> Permissions { get; set; } = null!;

    [JsonPropertyName("error")]
    public Error? Error { get; set; }

    public record Permission
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;
    }
}
