﻿using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.FineTunes;

public record ListFineTuneEventsResponse : ResponseBase
{
    [JsonPropertyName("object")]
    public string Object { get; set; } = null!;

    [JsonPropertyName("data")]
    public List<FineTuneResponseEvent> Data { get; set; } = new();
}
