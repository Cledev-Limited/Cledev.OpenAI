﻿using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.FineTunes;

public record DeleteFineTuneResponse : ResponseBase
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("deleted")]
    public bool Deleted { get; set; }
}
