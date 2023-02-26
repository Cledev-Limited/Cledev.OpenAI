using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Images;

/// <summary>
/// Creates an image given a prompt.
/// </summary>
public class CreateImageRequest : CreateImageRequestBase
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>A text description of the desired image(s). The maximum length is 1000 characters.</para>
    /// </summary>
    [JsonPropertyName("prompt")]
    public required string Prompt { get; set; }
}
