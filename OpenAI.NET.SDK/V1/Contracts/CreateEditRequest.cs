using System.Text.Json.Serialization;

namespace OpenAI.NET.SDK.V1.Contracts;

/// <summary>
/// Creates a new edit for the provided input, instruction, and parameters.
/// </summary>
public class CreateEditRequest
{
    /// <summary>
    /// <para>Required.</para>
    /// <para>ID of the model to use. You can use the text-davinci-edit-001 or code-davinci-edit-001 model with this endpoint.</para>
    /// </summary>
    [JsonPropertyName("model")]
    public required string Model { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to "").</para>
    /// <para>The input text to use as a starting point for the edit.</para>
    /// </summary>
    [JsonPropertyName("input")]
    public string? Input { get; set; }

    /// <summary>
    /// <para>Required.</para>
    /// <para>The instruction that tells the model how to edit the prompt.</para>
    /// </summary>
    [JsonPropertyName("instruction")]
    public required string Instruction { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>How many edits to generate for the input and instruction.</para>
    /// </summary>
    [JsonPropertyName("n")]
    public int? N { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>What sampling temperature to use. Higher values means the model will take more risks. Try 0.9 for more creative applications, and 0 (argmax sampling) for ones with a well-defined answer.</para>
    /// <para>We generally recommend altering this or top_p but not both.</para>
    /// </summary>
    [JsonPropertyName("temperature")]
    public int? Temperature { get; set; }

    /// <summary>
    /// <para>Optional (Defaults to 1).</para>
    /// <para>An alternative to sampling with temperature, called nucleus sampling, where the model considers the results of the tokens with top_p probability mass. So 0.1 means only the tokens comprising the top 10% probability mass are considered.</para>
    /// <para>We generally recommend altering this or temperature but not both.</para>
    /// </summary>
    [JsonPropertyName("top_p")]
    public int? TopP { get; set; }
}
