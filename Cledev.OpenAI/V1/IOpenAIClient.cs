using Cledev.OpenAI.V1.Contracts.Audio;
using Cledev.OpenAI.V1.Contracts.Chats;
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
    Task<ListModelsResponse?> ListModels(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a model instance, providing basic information about the model such as the owner and permissioning.
    /// </summary>
    /// <param name="id">The id of the model (e.g. text-davinci-003)</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<ModelResponse?> RetrieveModel(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a completion for the provided prompt and parameters.
    /// </summary>
    /// <param name="request">The create completion request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create completion response.</returns>
    Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a completion for the provided prompt and parameters as stream.
    /// </summary>
    /// <param name="request">The create completion request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create completion response.</returns>
    IAsyncEnumerable<CreateCompletionResponse> CreateCompletionAsStream(CreateCompletionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a chat completion for the provided messages and parameters.
    /// </summary>
    /// <param name="request">The create chat completion request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create chat completion response.</returns>
    Task<CreateChatCompletionResponse?> CreateChatCompletion(CreateChatCompletionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a chat completion for the provided messages and parameters as stream.
    /// </summary>
    /// <param name="request">The create chat completion request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create chat completion response.</returns>
    IAsyncEnumerable<CreateChatCompletionResponse> CreateChatCompletionAsStream(CreateChatCompletionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a new edit for the provided input, instruction, and parameters.
    /// </summary>
    /// <param name="request">The create edit request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create edit response</returns>
    Task<CreateEditResponse?> CreateEdit(CreateEditRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates an image given a prompt.
    /// </summary>
    /// <param name="request">The create image request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImage(CreateImageRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates an edited or extended image given an original image and a prompt.
    /// </summary>
    /// <param name="request">The create image edit request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a variation of a given image.
    /// </summary>
    /// <param name="request">The create image variation request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create image response.</returns>
    Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates an embedding vector representing the input text.
    /// </summary>
    /// <param name="request">The create embeddings request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create embeddings response.</returns>
    Task<CreateEmbeddingsResponse?> CreateEmbeddings(CreateEmbeddingsRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Transcribes audio into the input language.
    /// </summary>
    /// <param name="request">The create audio transcription request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create audio response.</returns>
    Task<CreateAudioResponse?> CreateAudioTranscription(CreateAudioTranscriptionRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Translates audio into into English.
    /// </summary>
    /// <param name="request">The create audio translation request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create audio response.</returns>
    Task<CreateAudioResponse?> CreateAudioTranslation(CreateAudioTranslationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of files that belong to the user's organization.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    Task<ListFilesResponse?> ListFiles(CancellationToken cancellationToken = default);

    /// <summary>
    /// Upload a file that contains document(s) to be used across various endpoints/features. Currently, the size of all the files uploaded by one organization can be up to 1 GB. Please contact us if you need to increase the storage limit.
    /// </summary>
    /// <param name="request">The upload file request</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The file response.</returns>
    Task<FileResponse?> UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The delete file response.</returns>
    Task<DeleteFileResponse?> DeleteFile(string fileId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns information about a specific file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The retrieve file response.</returns>
    Task<FileResponse?> RetrieveFile(string fileId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the contents of the specified file.
    /// </summary>
    /// <param name="fileId">The ID of the file to use for this request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The file content.</returns>
    Task<string?> RetrieveFileContent(string fileId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Creates a job that fine-tunes a specified model from a given dataset.
    /// Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
    /// </summary>
    /// <param name="request">The create fine tune request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The fine tune response.</returns>
    Task<FineTuneResponse?> CreateFineTune(CreateFineTuneRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// List your organization's fine-tuning jobs.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list fine tunes response.</returns>
    Task<ListFineTunesResponse?> ListFineTunes(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets info about the fine-tune job.
    /// </summary>
    /// <param name="fineTuneId">The ID of the fine-tune job.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The fine tune response.</returns>
    Task<FineTuneResponse?> RetrieveFineTune(string fineTuneId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Immediately cancel a fine-tune job.
    /// </summary>
    /// <param name="fineTuneId">The ID of the fine-tune job to cancel.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The fine tune response.</returns>
    Task<FineTuneResponse?> CancelFineTune(string fineTuneId, CancellationToken cancellationToken = default);

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
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns></returns>
    Task<ListFineTuneEventsResponse?> ListFineTuneEvents(string fineTuneId, bool? stream = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Delete a fine-tuned model. You must have the Owner role in your organization.
    /// </summary>
    /// <param name="model">The model to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The delete fine tune model response.</returns>
    Task<DeleteFineTuneResponse?> DeleteFineTune(string model, CancellationToken cancellationToken = default);

    /// <summary>
    /// Classifies if text violates OpenAI's Content Policy.
    /// </summary>
    /// <param name="request">The create moderation request.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The create moderation response.</returns>
    Task<CreateModerationResponse?> CreateModeration(CreateModerationRequest request, CancellationToken cancellationToken = default);
}
