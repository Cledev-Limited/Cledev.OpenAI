using OpenAI.NET.SDK.V1.Contracts;

namespace OpenAI.NET.SDK.V1;

public interface IOpenAIClient
{
    /// <summary>
    /// Lists the currently available models, and provides basic information about each one such as the owner and availability.
    /// </summary>
    Task<ListModelsResponse?> ListModels();

    /// <summary>
    /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
    /// </summary>
    /// <param name="id">The id of the model (e.g. text-davinci-003)</param>
    Task<RetrieveModelResponse?> RetrieveModel(string id);

    /// <summary>
    /// Creates a completion for the provided prompt and parameters.
    /// </summary>
    /// <param name="request">The create completion request.</param>
    /// <returns>The create completion response or failure.</returns>
    Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request);

    /// <summary>
    /// Creates a completion for the provided prompt and parameters.
    /// </summary>
    /// <param name="model">ID of the model to use (e.g. text-davinci-003).</param>
    /// <param name="prompt">
    /// <para>The prompt(s) to generate completions for, encoded as a string, array of strings, array of tokens, or array of token arrays.</para>
    /// <para>Note that &amp;lt;|endoftext|&amp;gt; is the document separator that the model sees during training, so if a prompt is not specified the model will generate as if from the beginning of a new document.</para>
    /// </param>
    /// <param name="maxTokens">
    /// <para>The maximum number of tokens to generate in the completion.</para>
    /// <para>The token count of your prompt plus max_tokens cannot exceed the model's context length. Most models have a context length of 2048 tokens (except for the newest models, which support 4096).</para>
    /// </param>
    /// <returns>The create completion response or failure.</returns>
    Task<CreateCompletionResponse?> CreateCompletion(CompletionsModel model, string? prompt = null, int? maxTokens = null);

    /// <summary>
    /// Creates a new edit for the provided input, instruction, and parameters.
    /// </summary>
    /// <param name="request">The create edit request.</param>
    /// <returns>The create edit response</returns>
    Task<CreateEditResponse?> CreateEdit(CreateEditRequest request);

    /// <summary>
    /// Creates a new edit for the provided input, instruction, and parameters.
    /// </summary>
    /// <param name="model">ID of the model to use (e.g. text-davinci-edit-001).</param>
    /// <param name="input">The input text to use as a starting point for the edit.</param>
    /// <param name="instruction">The instruction that tells the model how to edit the prompt.</param>
    /// <returns></returns>
    Task<CreateEditResponse?> CreateEdit(EditsModel model, string? input = null, string? instruction = null);

    /// <summary>
    /// Creates an image given a prompt.
    /// </summary>
    /// <param name="request">The create image request.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImage(CreateImageRequest request);

    /// <summary>
    /// Creates an image given a prompt.
    /// </summary>
    /// <param name="prompt">A text description of the desired image(s). The maximum length is 1000 characters.</param>
    /// <param name="numberOfImagesToGenerate">The number of images to generate. Must be between 1 and 10.</param>
    /// <param name="size">The size of the generated images. Must be one of 256x256, 512x512, or 1024x1024.</param>
    /// <param name="responseFormat">The format in which the generated images are returned. Must be one of url or b64_json.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImage(string prompt, int? numberOfImagesToGenerate = null, ImageSize? size = null, ImageResponseFormat? responseFormat = null);

    /// <summary>
    /// Creates an edited or extended image given an original image and a prompt.
    /// </summary>
    /// <param name="request">The create image edit request.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request);

    /// <summary>
    /// Creates a variation of a given image.
    /// </summary>
    /// <param name="request">The create image variation request.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request);

    /// <summary>
    /// Creates an embedding vector representing the input text.
    /// </summary>
    /// <param name="request">The create embeddings request.</param>
    /// <returns>The create embeddings response.</returns>
    Task<CreateEmbeddingsResponse?> CreateEmbeddings(CreateEmbeddingsRequest request);

    /// <summary>
    /// Returns a list of files that belong to the user's organization.
    /// </summary>
    Task<ListFilesResponse?> ListFiles();

    /// <summary>
    /// Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.
    /// </summary>
    /// <param name="file">The file.</param>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="purpose">The purpose of the file.</param>
    /// <returns>The upload file response.</returns>
    Task<UploadFileResponse?> UploadFile(byte[] file, string fileName, string purpose);

    /// <summary>
    /// Delete a file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request.</param>
    /// <returns>The delete file response.</returns>
    Task<DeleteFileResponse?> DeleteFile(string fileId);
}
