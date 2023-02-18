using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Moderations;

/// <summary>
/// Classifies if text violates OpenAI's Content Policy.
/// </summary>
public class CreateModerationRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>The input text to classify.</para>
    /// </summary>
    [JsonPropertyName("input")]
    public required string? Input { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to text-moderation-latest).</para>
    /// <para>Two content moderations models are available: text-moderation-stable and text-moderation-latest.</para>
    /// <para>The default is text-moderation-latest which will be automatically upgraded over time. This ensures you are always using our most accurate model. If you use text-moderation-stable, we will provide advanced notice before updating the model. Accuracy of text-moderation-stable may be slightly lower than for text-moderation-latest.</para>
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }
}
