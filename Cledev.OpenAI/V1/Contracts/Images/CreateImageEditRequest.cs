using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Images;

/// <summary>
/// Creates an edited or extended image given an original image and a prompt.
/// </summary>
public class CreateImageEditRequest : CreateImageRequestBase
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>The image to edit. Must be a valid PNG file, less than 4MB, and square. If mask is not provided, image must have transparency, which will be used as the mask.</para>
    /// </summary>
    public byte[] Image { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>The name of the image to edit.</para>
    /// </summary>
    public string ImageName { get; set; } = null!;

    /// <summary>
    /// <para>Optional.</para>
    /// <para>An additional image whose fully transparent areas (e.g. where alpha is zero) indicate where image should be edited. Must be a valid PNG file, less than 4MB, and have the same dimensions as image.</para>
    /// </summary>
    public byte[]? Mask { get; set; }

    /// <summary>
    /// <para>Optional.</para>
    /// <para>The name of the optional mask.</para>
    /// </summary>
    public string? MaskName { get; set; }

    /// <summary>
    /// <para>Required.</para>
    /// <para>A text description of the desired image(s). The maximum length is 1000 characters.</para>
    /// </summary>
    [JsonPropertyName("prompt")]
    public string Prompt { get; set; } = null!;
}
