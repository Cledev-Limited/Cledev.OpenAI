using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Models;

public record ListModelsResponse : ResponseBase
{
    [JsonPropertyName("data")]
    public List<ListModelsResponseData> Data { get; set; } = null!;
}

public record ListModelsResponseData
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("owned_by")]
    public string OwnedBy { get; set; } = null!;

    [JsonPropertyName("permissions")]
    public List<ListModelsResponseDataPermission> Permissions { get; set; } = null!;

}
public record ListModelsResponseDataPermission
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;
}
