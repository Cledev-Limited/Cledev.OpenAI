﻿using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Embeddings;

public record EmbeddingsData
{
    [JsonPropertyName("object")]
    public string? Object { get; set; }

    [JsonPropertyName("index")]
    public int? Index { get; set; }

    [JsonPropertyName("embedding")]
    public List<double> Embedding { get; set; } = new();
}
