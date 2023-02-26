namespace Cledev.OpenAI.V1.Contracts.Images;

/// <summary>
/// Creates a variation of a given image.
/// </summary>
public class CreateImageVariationRequest : CreateImageRequestBase
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>The image to use as the basis for the variation(s). Must be a valid PNG file, less than 4MB, and square.</para>
    /// </summary>
    public byte[] Image { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>The name of the image to edit.</para>
    /// </summary>
    public string ImageName { get; set; } = null!;
}
