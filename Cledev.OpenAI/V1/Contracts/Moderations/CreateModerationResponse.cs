using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Moderations;

public record CreateModerationResponse
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    [JsonPropertyName("results")] 
    public List<Result> Results { get; set; } = new ();

    public record Result
    {
        [JsonPropertyName("categories")]
        public Categories? Categories { get; set; }

        [JsonPropertyName("category_scores")]
        public CategoryScores? CategoryScores { get; set; }

        [JsonPropertyName("flagged")]
        public bool Flagged { get; set; }
    }

    public record Categories
    {
        [JsonPropertyName("hate")] 
        public bool Hate { get; set; }

        [JsonPropertyName("hate/threatening")] 
        public bool HateThreatening { get; set; }

        [JsonPropertyName("self-harm")] 
        public bool SelfHarm { get; set; }

        [JsonPropertyName("sexual")] 
        public bool Sexual { get; set; }

        [JsonPropertyName("sexual/minors")] 
        public bool SexualMinors { get; set; }

        [JsonPropertyName("violence")] 
        public bool Violence { get; set; }

        [JsonPropertyName("violence/graphic")] 
        public bool ViolenceGraphic { get; set; }
    }

    public record CategoryScores
    {
        [JsonPropertyName("hate")] 
        public float Hate { get; set; }

        [JsonPropertyName("hate/threatening")] 
        public float HateThreatening { get; set; }

        [JsonPropertyName("self-harm")] 
        public float SelfHarm { get; set; }

        [JsonPropertyName("sexual")] 
        public float Sexual { get; set; }

        [JsonPropertyName("sexual/minors")] 
        public float SexualMinors { get; set; }

        [JsonPropertyName("violence")] 
        public float Violence { get; set; }

        [JsonPropertyName("violence/graphic")] 
        public float ViolenceGraphic { get; set; }
    }
}
