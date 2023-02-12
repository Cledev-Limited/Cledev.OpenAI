using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.FineTunes;

public record ListFineTunesResponse
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("data")]
    public List<ListFineTunesResponseData> Data { get; set; } = new();

    public record ListFineTunesResponseData
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
        public FineTuneHyperParams? HyperParams { get; set; }

        [JsonPropertyName("organization_id")]
        public string? OrganizationId { get; set; }

        [JsonPropertyName("result_files")] 
        public List<FineTuneFile> ResultFiles { get; set; } = new();

        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;

        [JsonPropertyName("validation_files")] 
        public List<FineTuneFile> ValidationFiles { get; set; } = new();

        [JsonPropertyName("training_files")] 
        public List<FineTuneFile> TrainingFiles { get; set; } = new();

        [JsonPropertyName("updated_at")] 
        public int? UpdatedAt { get; set; }

        [JsonPropertyName("events")]
        public List<FineTuneEvent> Events { get; set; } = new();
    }
}
