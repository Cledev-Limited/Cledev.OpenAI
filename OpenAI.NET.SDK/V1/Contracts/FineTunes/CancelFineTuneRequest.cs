using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.FineTunes;

/// <summary>
/// Immediately cancel a fine-tune job.
/// </summary>
public record CancelFineTuneRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>The ID of the fine-tune job to cancel.</para>
    /// </summary>
    [JsonPropertyName("fine_tune_id")] 
    public required string FineTuneId { get; set; }
}
