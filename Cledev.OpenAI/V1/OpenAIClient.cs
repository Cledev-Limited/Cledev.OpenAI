using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using Cledev.OpenAI.Extensions;
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
    public async Task<ListModelsResponse?> ListModels(CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<ListModelsResponse?>($"/{ApiVersion}/models", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ModelResponse?> RetrieveModel(string id, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<ModelResponse?>($"/{ApiVersion}/models/{id}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateCompletionResponse>($"/{ApiVersion}/completions", request, cancellationToken);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<CreateCompletionResponse> CreateCompletionAsStream(CreateCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        request.Stream = true;

        using var httpResponseMessage = await _httpClient.PostAsStream($"/{ApiVersion}/completions", request, cancellationToken);
        await using var stream = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);
        using var streamReader = new StreamReader(stream);
        while (streamReader.EndOfStream is false)
        {
            var line = await streamReader.ReadLineAsync(cancellationToken);

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
                line += await streamReader.ReadToEndAsync(cancellationToken);
                createCompletionResponse = JsonSerializer.Deserialize<CreateCompletionResponse>(line);
            }

            if (createCompletionResponse is not null) 
            {
                yield return createCompletionResponse;
            }
        }
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateChatCompletion(CreateChatCompletionRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateCompletionResponse>($"/{ApiVersion}/chat/completions", request, cancellationToken);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<CreateChatCompletionResponse> CreateChatCompletionAsStream(CreateChatCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        request.Stream = true;

        using var httpResponseMessage = await _httpClient.PostAsStream($"/{ApiVersion}/chat/completions", request, cancellationToken);
        await using var stream = await httpResponseMessage.Content.ReadAsStreamAsync(cancellationToken);
        using var streamReader = new StreamReader(stream);
        while (streamReader.EndOfStream is false)
        {
            var line = await streamReader.ReadLineAsync(cancellationToken);

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
                line += await streamReader.ReadToEndAsync(cancellationToken);
                createChatCompletionResponse = JsonSerializer.Deserialize<CreateChatCompletionResponse>(line);
            }

            if (createChatCompletionResponse is not null)
            {
                yield return createChatCompletionResponse;
            }
        }
    }

    /// <inheritdoc />
    public async Task<CreateEditResponse?> CreateEdit(CreateEditRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateEditResponse>($"/{ApiVersion}/edits", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImage(CreateImageRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/generations", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/edits", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<CreateImageResponse>($"/{ApiVersion}/images/variations", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateEmbeddingsResponse?> CreateEmbeddings(CreateEmbeddingsRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateEmbeddingsResponse>($"/{ApiVersion}/embeddings", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateAudioResponse?> CreateAudioTranscription(CreateAudioTranscriptionRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        multipartFormDataContent.AddOtherOptionsFrom(request);
        return await _httpClient.Post<CreateAudioResponse>($"/{ApiVersion}/audio/transcriptions", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateAudioResponse?> CreateAudioTranslation(CreateAudioTranslationRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<CreateAudioResponse>($"/{ApiVersion}/audio/translations", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ListFilesResponse?> ListFiles(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<ListFilesResponse?>($"/{ApiVersion}/files", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FileResponse?> UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<FileResponse?>($"/{ApiVersion}/files", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DeleteFileResponse?> DeleteFile(string fileId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Delete<DeleteFileResponse?>($"/{ApiVersion}/files/{fileId}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FileResponse?> RetrieveFile(string fileId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<FileResponse?>($"/{ApiVersion}/files/{fileId}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<string?> RetrieveFileContent(string fileId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<string?>($"/{ApiVersion}/files/{fileId}/content", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> CreateFineTune(CreateFineTuneRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<FineTuneResponse?>($"/{ApiVersion}/fine-tunes", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ListFineTunesResponse?> ListFineTunes(CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<ListFineTunesResponse?>($"/{ApiVersion}/fine-tunes", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> RetrieveFineTune(string fineTuneId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<FineTuneResponse?>($"/{ApiVersion}/fine-tunes/{fineTuneId}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> CancelFineTune(string fineTuneId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<FineTuneResponse?>($"/{ApiVersion}/fine-tunes/{fineTuneId}/cancel", null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ListFineTuneEventsResponse?> ListFineTuneEvents(string fineTuneId, bool? stream = null, CancellationToken cancellationToken = default)
    {
        var queryParameters = stream is not null ? $"?stream={stream}" : string.Empty;
        return await _httpClient.Get<ListFineTuneEventsResponse?>($"/{ApiVersion}/fine-tunes/{fineTuneId}/events{queryParameters}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DeleteFineTuneResponse?> DeleteFineTune(string model, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Delete<DeleteFineTuneResponse?>($"/{ApiVersion}/models/{model}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateModerationResponse?> CreateModeration(CreateModerationRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateModerationResponse?>($"/{ApiVersion}/moderations", request, cancellationToken);
    }
}
