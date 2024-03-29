﻿using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Chats;

/// <summary>
/// Given a chat conversation, the model will return a chat completion response.
/// </summary>
public class CreateChatCompletionRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>ID of the model to use. Currently, only gpt-3.5-turbo and gpt-3.5-turbo-0301 are supported.</para>
    /// </summary>
    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>The messages to generate chat completions for, in the chat format.</para>
    /// </summary>
    [JsonPropertyName("messages")]
    public IList<ChatCompletionMessage> Messages { get; set; } = new List<ChatCompletionMessage>();

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.</para>
    ///<para>We generally recommend altering this or top_p but not both.</para>
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
    /// <para>Up to 4 sequences where the API will stop generating further tokens. The returned text will not contain the stop sequence.</para>
    /// </summary>
    [JsonPropertyName("stop")]
    public string? Stop { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 16).</para>
    /// <para>The maximum number of tokens to generate in the completion.</para>
    /// <para>The token count of your prompt plus max_tokens cannot exceed the model's context length. Most models have a context length of 2048 tokens (except for the newest models, which support 4096).</para>
    /// </summary>
    [JsonPropertyName("max_tokens")]
    public int? MaxTokens { get; set; }

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
