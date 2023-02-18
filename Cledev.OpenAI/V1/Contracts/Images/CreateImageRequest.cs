using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Images;

/// <summary>
/// Creates an image given a prompt.
/// </summary>
public class CreateImageRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>A text description of the desired image(s). The maximum length is 1000 characters.</para>
    /// </summary>
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>The number of images to generate. Must be between 1 and 10.</para>
    /// </summary>
    [JsonPropertyName("n")]
    public required int? N { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1024x1024).</para>
    /// <para>The number of images to generate. Must be between 1 and 10.</para>
    /// </summary>
    [JsonPropertyName("size")]
    public string? Size { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to url).</para>
    /// <para>The format in which the generated images are returned. Must be one of url or b64_json.</para>
    /// </summary>
    [JsonPropertyName("response_format")]
    public required string? ResponseFormat { get; set; }

    /// <summary>
    /// <para>Optional.</para>
    /// <para>A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse. </para>
    /// </summary>
    [JsonPropertyName("user")]
    public string? User { get; set; }
}
