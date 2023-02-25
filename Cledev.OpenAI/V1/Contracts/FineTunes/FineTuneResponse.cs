using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.FineTunes;

public record FineTuneResponse : ResponseBase
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("fine_tuned_model")]
    public string? FineTunedModel { get; set; }

    [JsonPropertyName("hyperparams")]
    public FineTuneResponseHyperParams? HyperParams { get; set; }

    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [JsonPropertyName("result_files")]
    public List<FineTuneResponseFile> ResultFiles { get; set; } = new();

    [JsonPropertyName("status")]
    public string Status { get; set; } = null!;

    [JsonPropertyName("validation_files")]
    public List<FineTuneResponseFile> ValidationFiles { get; set; } = new();

    [JsonPropertyName("training_files")]
    public List<FineTuneResponseFile> TrainingFiles { get; set; } = new();

    [JsonPropertyName("updated_at")]
    public int? UpdatedAt { get; set; }

    [JsonPropertyName("events")]
    public List<FineTuneResponseEvent> Events { get; set; } = new();
}
