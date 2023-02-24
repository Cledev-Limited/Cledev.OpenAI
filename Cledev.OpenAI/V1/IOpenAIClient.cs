using Cledev.OpenAI.V1.Contracts.Completions;
using Cledev.OpenAI.V1.Contracts.Edits;
using Cledev.OpenAI.V1.Contracts.Embeddings;
using Cledev.OpenAI.V1.Contracts.Files;
using Cledev.OpenAI.V1.Contracts.FineTunes;
using Cledev.OpenAI.V1.Contracts.Images;
using Cledev.OpenAI.V1.Contracts.Models;
using Cledev.OpenAI.V1.Contracts.Moderations;

namespace Cledev.OpenAI.V1;

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
    /// <returns>The create completion response.</returns>
    Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request);

    /// <summary>
    /// Creates a completion for the provided prompt and parameters as stream.
    /// </summary>
    /// <param name="request">The create completion request.</param>
    /// <returns>The create completion response.</returns>
    IAsyncEnumerable<CreateCompletionResponse> CreateCompletionAsStream(CreateCompletionRequest request);

    /// <summary>
    /// Creates a new edit for the provided input, instruction, and parameters.
    /// </summary>
    /// <param name="request">The create edit request.</param>
    /// <returns>The create edit response</returns>
    Task<CreateEditResponse?> CreateEdit(CreateEditRequest request);

    /// <summary>
    /// Creates an image given a prompt.
    /// </summary>
    /// <param name="request">The create image request.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImage(CreateImageRequest request);

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
    /// <returns>The file response.</returns>
    Task<FileResponse?> UploadFile(byte[] file, string fileName, string purpose);

    /// <summary>
    /// Delete a file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request.</param>
    /// <returns>The delete file response.</returns>
    Task<DeleteFileResponse?> DeleteFile(string fileId);

    /// <summary>
    /// Returns information about a specific file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request.</param>
    /// <returns>The retrieve file response.</returns>
    Task<FileResponse?> RetrieveFile(string fileId);

    /// <summary>
    /// Creates a job that fine-tunes a specified model from a given dataset.
    /// Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
    /// </summary>
    /// <param name="request">The create fine tune request.</param>
    /// <returns>The fine tune response.</returns>
    Task<FineTuneResponse?> CreateFineTune(CreateFineTuneRequest request);

    /// <summary>
    /// List your organization's fine-tuning jobs.
    /// </summary>
    /// <returns>The list fine tunes response.</returns>
    Task<ListFineTunesResponse?> ListFineTunes();

    /// <summary>
    /// Gets info about the fine-tune job.
    /// </summary>
    /// <param name="fineTuneId">The ID of the fine-tune job.</param>
    /// <returns>The fine tune response.</returns>
    Task<FineTuneResponse?> RetrieveFineTune(string fineTuneId);

    /// <summary>
    /// Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="fineTuneId">The ID of the fine-tune job to cancel.</param>
    /// <returns>The fine tune response.</returns>
    Task<FineTuneResponse?> CancelFineTune(string fineTuneId);

    /// <summary>
    /// Get fine-grained status updates for a fine-tune job.
    /// </summary>
    /// <param name="fineTuneId">
    /// <para>Required.</para>
    /// <para>The ID of the fine-tune job to get events for.</para>
    /// </param>
    /// <param name="stream">
    /// <para>Optional (Defaults to false).</para>
    /// <para>Whether to stream events for the fine-tune job. If set to true, events will be sent as data-only server-sent events as they become available. The stream will terminate with a data: [DONE] message when the job is finished (succeeded, cancelled, or failed).</para>
    /// <para>If set to false, only events generated so far will be returned.</para>
    /// </param>
    /// <returns></returns>
    Task<ListFineTuneEventsResponse?> ListFineTuneEvents(string fineTuneId, bool? stream = null);

    /// <summary>
    /// Delete a fine-tuned model. You must have the Owner role in your organization.
    /// </summary>
    /// <param name="model">The model to delete.</param>
    /// <returns>The delete fine tune model response.</returns>
    Task<DeleteFineTuneResponse?> DeleteFineTune(string model);

    /// <summary>
    /// Classifies if text violates OpenAI's Content Policy.
    /// </summary>
    /// <param name="request">The create moderation request.</param>
    /// <returns>The create moderation response.</returns>
    Task<CreateModerationResponse?> CreateModeration(CreateModerationRequest request);
}
