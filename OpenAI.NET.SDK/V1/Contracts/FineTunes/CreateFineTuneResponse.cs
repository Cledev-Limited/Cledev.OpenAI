using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.FineTunes;

public record CreateFineTuneResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("created_at")]
    public int CreatedAt { get; set; }

    [JsonPropertyName("events")] public List<CreateFineTuneResponseEvent> Events { get; set; } = new();

    [JsonPropertyName("fine_tuned_model")] 
    public string? FineTunedModel { get; set; }

    [JsonPropertyName("hyperparams")] 
    public CreateFineTuneResponseHyperParams? HyperParams { get; set; }

    [JsonPropertyName("organization_id")] 
    public string? OrganizationId { get; set; }

    [JsonPropertyName("result_files")] public List<CreateFineTuneResponseFile> ResultFiles { get; set; } = new();

    [JsonPropertyName("status")] 
    public string Status { get; set; } = null!;

    [JsonPropertyName("validation_files")]
    public List<CreateFineTuneResponseFile> ValidationFiles { get; set; } = new();

    [JsonPropertyName("training_files")] public List<CreateFineTuneResponseFile> TrainingFiles { get; set; } = new();

    [JsonPropertyName("updated_at")] 
    public int? UpdatedAt { get; set; }

    public class CreateFineTuneResponseEvent
    {
        [JsonPropertyName("object")]
        public string Object { get; set; } = null!;

        [JsonPropertyName("created_at")]
        public int CreatedAt { get; set; }

        [JsonPropertyName("level")] 
        public string Level { get; set; } = null!;

        [JsonPropertyName("message")] 
        public string Message { get; set; } = null!;
    }

    public record CreateFineTuneResponseHyperParams
    {
        [JsonPropertyName("batch_size")] 
        public int? BatchSize { get; set; }

        [JsonPropertyName("learning_rate_multiplier")]
        public float? LearningRateMultiplier { get; set; }

        [JsonPropertyName("n_epochs")] 
        public int? NEpochs { get; set; }

        [JsonPropertyName("prompt_loss_weight")]
        public float? PromptLossWeight { get; set; }
    }

    public record CreateFineTuneResponseFile
    {
        [JsonPropertyName("id")] 
        public string Id { get; set; } = null!;

        [JsonPropertyName("object")]
        public string Object { get; set; } = null!;

        [JsonPropertyName("bytes")] 
        public int? Bytes { get; set; }

        [JsonPropertyName("created_at")] 
        public int CreatedAt { get; set; }

        [JsonPropertyName("filename")] 
        public string FileName { get; set; } = null!;

        [JsonPropertyName("purpose")] 
        public string? Purpose { get; set; }
    }
}
