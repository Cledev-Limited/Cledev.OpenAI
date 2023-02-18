using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Images;

/// <summary>
/// Creates a variation of a given image.
/// </summary>
public class CreateImageVariationRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB, and square.</para>
    /// </summary>
    [JsonPropertyName("image")]
    public required string Image { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>The number of images to generate. Must be between 1 and 10.</para>
    /// </summary>
    [JsonPropertyName("n")]
    public required int? N { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1024x1024).</para>
    /// <para>The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.</para>
    /// </summary>
    [JsonPropertyName("size")]
    public required string? Size { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to url).</para>
    /// <para>The format in which the generated images are returned. Must be one of url or b64_json.</para>
    /// </summary>
    [JsonPropertyName("response_format")]
    public required string? ResponseFormat { get; set; }

    /// <summary>
    /// <para>Optional.</para>
    /// <para>A unique identifier representing your end-user, which can help OpenAI to monitor and detect abuse.</para>
    /// </summary>
    [JsonPropertyName("user")]
    public string? User { get; set; }
}
