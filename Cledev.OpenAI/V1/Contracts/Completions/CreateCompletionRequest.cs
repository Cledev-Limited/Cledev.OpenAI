using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Completions;

/// <summary>
/// Creates a completion for the provided prompt and parameters.
/// </summary>
public class CreateCompletionRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.</para>
    /// </summary>
    [JsonPropertyName("model")]
    public required string Model { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to &amp;lt;|endoftext|&amp;rt;).</para>
    /// <para>The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of token arrays.</para>
    /// <para>Note that &amp;lt;|endoftext|&amp;rt; is the document separator that the model sees during training, so if a prompt is not specified the model will generate as if from the beginning of a new document.</para>
    /// </summary>
    [JsonPropertyName("prompt")]
    public string? Prompt { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>The suffix that comes after a completion of inserted text.</para>
    /// </summary>
    [JsonPropertyName("suffix")]
    public string? Suffix { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 16).</para>
    /// <para>The maximum number of tokens to generate in the completion.</para>
    /// <para>The token count of your prompt plus max_tokens cannot exceed the model's context length. Most models have a context length of 2048 tokens (except for the newest models, which support 4096).</para>
    /// </summary>
    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.</para>
    /// <para>We generally recommend altering this or top_p but not both.</para>
    /// </summary>
    [JsonPropertyName("temperature")]
    public float? Temperature { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.</para>
    /// <para>We generally recommend altering this or temperature but not both.</para>
    /// </summary>
    [JsonPropertyName("top_p")]
    public float? TopP { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>How many completions to generate for each prompt.</para>
    /// <para>Note: Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for max_tokens and stop.</para>
    /// </summary>
    [JsonPropertyName("n")]
    public int? N { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to false).</para>
    /// <para>Whether to stream back partial progress. If set, tokens will be sent as data-only server-sent events as they become available, with the stream terminated by a data: [DONE] message.</para>
    /// </summary>
    [JsonPropertyName("stream")]
    public bool Stream { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>Include the log probabilities on the logprobs most likely tokens, as well the chosen tokens. For example, if logprobs is 5, the API will return a list of the 5 most likely tokens. The API will always return the logprob of the sampled token, so there may be up to logprobs+1 elements in the response.</para>
    /// <para>The maximum value for logprobs is 5. If you need more than this, please contact us through our Help center and describe your use case.</para>
    /// </summary>
    [JsonPropertyName("logprobs")]
    public int? LogProbs { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to false).</para>
    /// <para>Echo back the prompt in addition to the completion.</para>
    /// </summary>
    [JsonPropertyName("echo")]
    public bool Echo { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.</para>
    /// </summary>
    [JsonPropertyName("stop")]
    public string? Stop { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 0).</para>
    /// <para>Number between -2.0 and 2.0. Positive values penalize new tokens based on whether they appear in the text so far, increasing the model's likelihood to talk about new topics.</para>
    /// </summary>
    [JsonPropertyName("presence_penalty")]
    public float? PresencePenalty { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 0).</para>
    /// <para>Number between -2.0 and 2.0. Positive values penalize new tokens based on their existing frequency in the text so far, decreasing the model's likelihood to repeat the same line verbatim.</para>
    /// </summary>
    [JsonPropertyName("frequency_penalty")]
    public float? FrequencyPenalty { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>Generates best_of completions server-side and returns the "best" (the one with the highest log probability per token). Results cannot be streamed.</para>
    /// <para>When used with n, best_of controls the number of candidate completions and n specifies how many to return – best_of must be greater than n.</para>
    /// <para>Note: Because this parameter generates many completions, it can quickly consume your token quota. Use carefully and ensure that you have reasonable settings for max_tokens and stop.</para>
    /// </summary>
    [JsonPropertyName("best_of")]
    public int? BestOf { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to null).</para>
    /// <para>Modify the likelihood of specified tokens appearing in the completion.</para>
    /// <para>Accepts a json object that maps tokens (specified by their token ID in the GPT tokenizer) to an associated bias value from -100 to 100. You can use this tokenizer tool (which works for both GPT-2 and GPT-3) to convert text to token IDs. Mathematically, the bias is added to the logits generated by the model prior to sampling. The exact effect will vary per model, but values between -1 and 1 should decrease or increase likelihood of selection; values like -100 or 100 should result in a ban or exclusive selection of the relevant token.</para>
    /// <para>As an example, you can pass {"50256": -100} to prevent the &amp;lt;|endoftext|&amp;rt; token from being generated.</para>
    /// </summary>
    [JsonPropertyName("logit_bias")]
    public string? LogitBias { get; set; }

    /// <summary>
    /// <para>Optional.</para>
    /// <para>A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.</para>
    /// </summary>
    [JsonPropertyName("user")]
    public string? User { get; set; }
}
