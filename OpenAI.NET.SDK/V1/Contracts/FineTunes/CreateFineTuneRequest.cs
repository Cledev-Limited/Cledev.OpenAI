using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts.FineTunes;

/// <summary>
/// Creates a job that fine-tunes a specified model from a given dataset.
/// </summary>
public class CreateFineTuneRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>The ID of an uploaded file that contains training data.</para>
    /// <para>Your dataset must be formatted as a JSONL file, where each training example is a JSON object with the keys "prompt" and "completion". Additionally, you must upload your file with the purpose fine-tune.</para>
    /// </summary>
    [JsonPropertyName("training_file")]
    public required string TrainingFile { get; set; }

    /// <summary>
    /// <para>Optional.</para>
    /// <para>The ID of an uploaded file that contains validation data.</para>
    /// <para>If you provide this file, the data is used to generate validation metrics periodically during fine-tuning. These metrics can be viewed in the fine-tuning results file. Your train and validation data should be mutually exclusive.</para>
    /// <para>Your dataset must be formatted as a JSONL file, where each validation example is a JSON object with the keys "prompt" and "completion". Additionally, you must upload your file with the purpose fine-tune.</para>
    /// </summary>
    [JsonPropertyName("validation_file")]
    public string? ValidationFile { get; set; }
}