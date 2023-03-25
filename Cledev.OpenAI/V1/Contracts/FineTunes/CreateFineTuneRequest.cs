using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.FineTunes;

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

    /// <summary>
    /// <para>Optional (Defaults to curie).</para>
    /// <para>The name of the base model to fine-tune. You can select one of "ada", "babbage", "curie", "davinci", or a fine-tuned model created after 2022-04-21. To learn more about these models, see the Models documentation.</para>
    /// </summary>
    [JsonPropertyName("model")]
    public string? Model { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 4).</para>
    /// <para>The number of epochs to train the model for. An epoch refers to one full cycle through the training dataset.</para>
    /// </summary>
    [JsonPropertyName("n_epochs")]
    public int? NEpochs { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>The batch size to use for training. The batch size is the number of training examples used to train a single forward and backward pass.</para>
    /// <para>By default, the batch size will be dynamically configured to be ~0.2% of the number of examples in the training set, capped at 256 - in general, we've found that larger batch sizes tend to work better for larger datasets.</para>
    /// </summary>
    [JsonPropertyName("batch_size")]
    public int? BatchSize { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>The learning rate multiplier to use for training. The fine-tuning learning rate is the original learning rate used for pretraining multiplied by this value.</para>
    /// <para>By default, the learning rate multiplier is the 0.05, 0.1, or 0.2 depending on final batch_size (larger learning rates tend to perform better with larger batch sizes). We recommend experimenting with values in the range 0.02 to 0.2 to see what produces the best results.</para>
    /// </summary>
    [JsonPropertyName("learning_rate_multiplier")]
    public float? LearningRateMultiplier { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 0.01).</para>
    /// <para>The weight to use for loss on the prompt tokens. This controls how much the model tries to learn to generate the prompt (as compared to the completion which always has a weight of 1.0), and can add a stabilizing effect to training when completions are short.</para>
    /// <para>If prompts are extremely long (relative to completions), it may make sense to reduce this weight so as to avoid over-prioritizing learning the prompt.</para>
    /// </summary>
    [JsonPropertyName("prompt_loss_weight")]
    public float? PromptLossWeight { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to false).</para>
    /// <para>If set, we calculate classification-specific metrics such as accuracy and F-1 score using the validation set at the end of every epoch. These metrics can be viewed in the results file.</para>
    /// <para>In order to compute classification metrics, you must provide a validation_file. Additionally, you must specify classification_n_classes for multiclass classification or classification_positive_class for binary classification.</para>
    /// </summary>
    [JsonPropertyName("compute_classification_metrics")]
    public bool ComputeClassificationMetrics { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>The number of classes in a classification task.</para>
    /// <para>This parameter is required for multiclass classification.</para>
    /// </summary>
    [JsonPropertyName("classification_n_classes")]
    public int? ClassificationNClasses { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>This parameter is required for multiclass classification.</para>
    /// <para>This parameter is needed to generate precision, recall, and F1 metrics when doing binary classification.</para>
    /// </summary>
    [JsonPropertyName("classification_positive_class")]
    public string? ClassificationPositiveClass { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>If this is provided, we calculate F-beta scores at the specified beta values. The F-beta score is a generalization of F-1 score. This is only used for binary classification.</para>
    /// <para>With a beta of 1 (i.e. the F-1 score), precision and recall are given the same weight. A larger beta score puts more weight on recall and less on precision. A smaller beta score puts more weight on precision and less on recall.</para>
    /// </summary>
    [JsonPropertyName("classification_betas")]
    public List<string>? ClassificationBetas { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>A string of up to 40 characters that will be added to your fine-tuned model name.</para>
    /// <para>For example, a suffix of "custom-model-name" would produce a model name like ada:ft-your-org:custom-model-name-2022-02-15-04-21-04.</para>
    /// </summary>
    [JsonPropertyName("suffix")]
    public string? Suffix { get; set; }
}
