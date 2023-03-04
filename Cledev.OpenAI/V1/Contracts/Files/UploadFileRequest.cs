using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Files;

/// <summary>
/// Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.
/// </summary>
public class UploadFileRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>Name of the JSON Lines file to be uploaded.</para>
    /// <para>If the purpose is set to "fine-tune", each line is a JSON record with "prompt" and "completion" fields representing your training examples.</para>
    /// </summary>
    public byte[] File { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>The name of the file to upload.</para>
    /// </summary>
    public string FileName { get; set; } = null!;

    /// <summary>
    /// <para>Required.</para>
    /// <para>The intended purpose of the uploaded documents.</para>
    /// <para>Use "fine-tune" for Fine-tuning. This allows us to validate the format of the uploaded file.</para>
    /// </summary>
    public string Purpose { get; set; } = null!;
}
