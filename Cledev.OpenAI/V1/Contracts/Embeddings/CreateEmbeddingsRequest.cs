using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Embeddings;

/// <summary>
/// Creates an embedding vector representing the input text.
/// </summary>
public class CreateEmbeddingsRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>ID of the model to use. You can use the List models API to see all of your available models, or see our Model overview for descriptions of them.</para>
    /// </summary>
    [JsonPropertyName("model")]
    public string Model { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>Input text to get embeddings for, encoded as a string or array of tokens. To get embeddings for multiple inputs in a single request, pass an array of strings or array of token arrays. Each input must not exceed 8192 tokens in length.</para>
    /// </summary>
    [JsonPropertyName("input")]
    public string Input { get; set; } = null!;

    /// <summary>
    /// <para>Optional.</para>
    /// <para>A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. </para>
    /// </summary>
    [JsonPropertyName("user")]
    public string? User { get; set; }
}
