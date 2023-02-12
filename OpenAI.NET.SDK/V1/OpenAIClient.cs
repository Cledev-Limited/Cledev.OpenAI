using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using OpenAI.NET.SDK.Extensions;
using OpenAI.NET.SDK.V1.Contracts.Completions;
using OpenAI.NET.SDK.V1.Contracts.Edits;
using OpenAI.NET.SDK.V1.Contracts.Embeddings;
using OpenAI.NET.SDK.V1.Contracts.Files;
using OpenAI.NET.SDK.V1.Contracts.FineTunes;
using OpenAI.NET.SDK.V1.Contracts.Images;
using OpenAI.NET.SDK.V1.Contracts.Models;
using OpenAI.NET.SDK.V1.Contracts.Moderations;

namespace OpenAI.NET.SDK.V1;

public class OpenAIClient : IOpenAIClient
{
    private const string ApiVersion = "v1";

    private readonly HttpClient _httpClient;

    public OpenAIClient(HttpClient httpClient, IOptions<Settings> options)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.openai.com/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.Value.ApiKey}");
        if (string.IsNullOrEmpty(options.Value.Organization) is false)
        {
            _httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", $"{options.Value.Organization}");
        }
    }

    /// <inheritdoc />
    public async Task<ListModelsResponse?> ListModels()
    {
        return await _httpClient.Get<ListModelsResponse?>($"/{ApiVersion}/models");
    }

    /// <inheritdoc />
    public async Task<RetrieveModelResponse?> RetrieveModel(string id)
    {
        return await _httpClient.Get<RetrieveModelResponse?>($"/{ApiVersion}/models/{id}");
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request)
    {
        return await _httpClient.Post<CreateCompletionResponse>($"/{ApiVersion}/completions", request);
    }

    /// <inheritdoc />
    public async Task<CreateEditResponse?> CreateEdit(CreateEditRequest request)
    {
        return await _httpClient.Post<CreateEditResponse>($"/{ApiVersion}/edits", request);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImage(CreateImageRequest request)
    {
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/generations", request);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request)
    {
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/edits", request);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request)
    {
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/variations", request);
    }

    /// <inheritdoc />
    public async Task<CreateEmbeddingsResponse?> CreateEmbeddings(CreateEmbeddingsRequest request)
    {
        return await _httpClient.Post<CreateEmbeddingsResponse>($"/{ApiVersion}/embeddings", request);
    }

    /// <inheritdoc />
    public async Task<ListFilesResponse?> ListFiles()
    {
        return await _httpClient.GetFromJsonAsync<ListFilesResponse?>($"/{ApiVersion}/files");
    }

    /// <inheritdoc />
    public async Task<UploadFileResponse?> UploadFile(byte[] file, string fileName, string purpose)
    {
        var multipartFormDataContent = new MultipartFormDataContent
        {
            { new ByteArrayContent(file), "file", fileName },
            { new StringContent(purpose), "purpose" }
        };

        return await _httpClient.Post<UploadFileResponse?>($"/{ApiVersion}/files", multipartFormDataContent);
    }

    /// <inheritdoc />
    public async Task<DeleteFileResponse?> DeleteFile(string fileId)
    {
        return await _httpClient.Delete<DeleteFileResponse?>($"/{ApiVersion}/files/{fileId}");
    }

    /// <inheritdoc />
    public async Task<RetrieveFileResponse?> RetrieveFile(string fileId)
    {
        return await _httpClient.Get<RetrieveFileResponse?>($"/{ApiVersion}/files/{fileId}");
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> CreateFineTune(CreateFineTuneRequest request)
    {
        return await _httpClient.Post<FineTuneResponse?>($"/{ApiVersion}/fine-tunes", request);
    }

    /// <inheritdoc />
    public async Task<ListFineTunesResponse?> ListFineTunes()
    {
        return await _httpClient.Get<ListFineTunesResponse?>($"/{ApiVersion}/fine-tunes");
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> RetrieveFineTune(string fineTuneId)
    {
        return await _httpClient.Get<FineTuneResponse?>($"/{ApiVersion}/fine-tunes/{fineTuneId}");
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> CancelFineTune(string fineTuneId)
    {
        return await _httpClient.Post<FineTuneResponse?>($"/{ApiVersion}/fine-tunes/{fineTuneId}/cancel", null);
    }

    /// <inheritdoc />
    public async Task<ListFineTuneEventsResponse?> ListFineTuneEvents(string fineTuneId, bool? stream = null)
    {
        var queryParameters = stream is not null ? $"?stream={stream}" : string.Empty;
        return await _httpClient.Get<ListFineTuneEventsResponse?>($"/{ApiVersion}/fine-tunes/{fineTuneId}/events{queryParameters}");
    }

    /// <inheritdoc />
    public async Task<DeleteFineTuneResponse?> DeleteFineTune(string model)
    {
        return await _httpClient.Delete<DeleteFineTuneResponse?>($"/{ApiVersion}/models/{model}");
    }

    /// <inheritdoc />
    public async Task<CreateModerationResponse?> CreateModeration(CreateModerationRequest request)
    {
        return await _httpClient.Post<CreateModerationResponse?>($"/{ApiVersion}/moderations", request);
    }
}
