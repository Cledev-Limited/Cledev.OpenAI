﻿using OpenAI.NET.SDK.V1.Contracts.Completions;
using OpenAI.NET.SDK.V1.Contracts.Edits;
using OpenAI.NET.SDK.V1.Contracts.Embeddings;
using OpenAI.NET.SDK.V1.Contracts.Files;
using OpenAI.NET.SDK.V1.Contracts.FineTunes;
using OpenAI.NET.SDK.V1.Contracts.Images;
using OpenAI.NET.SDK.V1.Contracts.Models;
using System.Numerics;
using System.Text;
using System.Xml.Linq;

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
    /// <returns>The upload file response.</returns>
    Task<UploadFileResponse?> UploadFile(byte[] file, string fileName, string purpose);

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
    Task<RetrieveFileResponse?> RetrieveFile(string fileId);

    /// <summary>
    /// Creates a job that fine-tunes a specified model from a given dataset.
    /// Response includes details of the enqueued job including job status and the name of the fine-tuned models once complete.
    /// </summary>
    /// <param name="request">The create fine tune request.</param>
    /// <returns>The create fine tune response.</returns>
    Task<CreateFineTuneResponse?> CreateFineTune(CreateFineTuneRequest request);
}
