using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Models;

public record ListModelsResponse : ResponseBase
{
    [JsonPropertyName("data")]
    public List<ModelResponse> Data { get; set; } = null!;
}
