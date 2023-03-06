using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Audio;

public record CreateAudioResponse : ResponseBase
{
    [JsonPropertyName("text")]
    public string? Text { get; set; }

    [JsonPropertyName("task")] 
    public string? Task { get; set; }

    [JsonPropertyName("language")] 
    public string? Language { get; set; }

    [JsonPropertyName("duration")] 
    public float? Duration { get; set; }

    [JsonPropertyName("segments")] 
    public List<Segment>? Segments { get; set; }

    public record Segment
    {
        [JsonPropertyName("id")] 
        public int Id { get; set; }

        [JsonPropertyName("seek")] 
        public int Seek { get; set; }

        [JsonPropertyName("start")] 
        public float Start { get; set; }

        [JsonPropertyName("end")] 
        public float End { get; set; }

        [JsonPropertyName("text")] 
        public string Text { get; set; } = null!;

        [JsonPropertyName("tokens")] 
        public List<int> Tokens { get; set; } = null!;

        [JsonPropertyName("temperature")] 
        public float Temperature { get; set; }

        [JsonPropertyName("avg_logprob")] 
        public float AvgLogProb { get; set; }

        [JsonPropertyName("compression_ratio")]
        public float CompressionRatio { get; set; }

        [JsonPropertyName("no_speech_prob")] 
        public float NoSpeechProb { get; set; }

        [JsonPropertyName("transient")] 
        public bool Transient { get; set; }
    }
}
