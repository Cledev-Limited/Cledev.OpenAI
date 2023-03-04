using System.Net.Http.Json;
using System.Text.Json;
using Cledev.OpenAI.Extensions;
using Cledev.OpenAI.V1.Contracts.Chats;
using Cledev.OpenAI.V1.Contracts.Completions;
using Cledev.OpenAI.V1.Contracts.Edits;
using Cledev.OpenAI.V1.Contracts.Embeddings;
using Cledev.OpenAI.V1.Contracts.Files;
using Cledev.OpenAI.V1.Contracts.FineTunes;
using Cledev.OpenAI.V1.Contracts.Images;
using Cledev.OpenAI.V1.Contracts.Models;
using Cledev.OpenAI.V1.Contracts.Moderations;
using Microsoft.Extensions.Options;

namespace Cledev.OpenAI.V1;

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
    public async Task<ModelResponse?> RetrieveModel(string id)
    {
        return await _httpClient.Get<ModelResponse?>($"/{ApiVersion}/models/{id}");
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateChatCompletion(CreateChatCompletionRequest request)
    {
        return await _httpClient.Post<CreateCompletionResponse>($"/{ApiVersion}/chat/completions", request);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<CreateChatCompletionResponse> CreateChatCompletionAsStream(CreateChatCompletionRequest request)
    {
        request.Stream = true;

        using var httpResponseMessage = await _httpClient.PostAsStream($"/{ApiVersion}/chat/completions", request);
        await using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
        using var streamReader = new StreamReader(stream);
        while (streamReader.EndOfStream is false)
        {
            var line = await streamReader.ReadLineAsync();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var dataPosition = line.IndexOf("data: ", StringComparison.Ordinal);
            line = dataPosition != 0 ? line : line["data: ".Length..];

            if (line.StartsWith("[DONE]"))
            {
                break;
            }

            CreateChatCompletionResponse? createChatCompletionResponse;

            try
            {
                createChatCompletionResponse = JsonSerializer.Deserialize<CreateChatCompletionResponse>(line);
            }
            catch (Exception)
            {
                line += await streamReader.ReadToEndAsync();
                createChatCompletionResponse = JsonSerializer.Deserialize<CreateChatCompletionResponse>(line);
            }

            if (createChatCompletionResponse is not null)
            {
                yield return createChatCompletionResponse;
            }
        }
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request)
    {
        return await _httpClient.Post<CreateCompletionResponse>($"/{ApiVersion}/completions", request);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<CreateCompletionResponse> CreateCompletionAsStream(CreateCompletionRequest request)
    {
        request.Stream = true;

        using var httpResponseMessage = await _httpClient.PostAsStream($"/{ApiVersion}/completions", request);
        await using var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
        using var streamReader = new StreamReader(stream);
        while (streamReader.EndOfStream is false)
        {
            var line = await streamReader.ReadLineAsync();

            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            var dataPosition = line.IndexOf("data: ", StringComparison.Ordinal);
            line = dataPosition != 0 ? line : line["data: ".Length..];

            if (line.StartsWith("[DONE]"))
            {
                break;
            }

            CreateCompletionResponse? createCompletionResponse;

            try
            {
                createCompletionResponse = JsonSerializer.Deserialize<CreateCompletionResponse>(line);
            }
            catch (Exception)
            {
                line += await streamReader.ReadToEndAsync();
                createCompletionResponse = JsonSerializer.Deserialize<CreateCompletionResponse>(line);
            }

            if (createCompletionResponse is not null) 
            {
                yield return createCompletionResponse;
            }
        }
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
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/edits", multipartFormDataContent);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/variations", multipartFormDataContent);
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
    public async Task<FileResponse?> UploadFile(UploadFileRequest request)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<FileResponse?>($"/{ApiVersion}/files", multipartFormDataContent);
    }

    /// <inheritdoc />
    public async Task<DeleteFileResponse?> DeleteFile(string fileId)
    {
        return await _httpClient.Delete<DeleteFileResponse?>($"/{ApiVersion}/files/{fileId}");
    }

    /// <inheritdoc />
    public async Task<FileResponse?> RetrieveFile(string fileId)
    {
        return await _httpClient.Get<FileResponse?>($"/{ApiVersion}/files/{fileId}");
    }

    /// <inheritdoc />
    public async Task<string?> RetrieveFileContent(string fileId)
    {
        return await _httpClient.Get<string?>($"/{ApiVersion}/files/{fileId}/content");
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
