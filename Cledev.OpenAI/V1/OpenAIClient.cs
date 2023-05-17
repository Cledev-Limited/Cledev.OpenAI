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
using Cledev.OpenAI.V1.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Cledev.OpenAI.V1;

public class OpenAIClient : IOpenAIClient
{
    private const string ApiVersion = "v1";

    private readonly HttpClient _httpClient;

    [ActivatorUtilitiesConstructor]
    public OpenAIClient(HttpClient httpClient, IOptions<Settings> settings)
        : this(settings.Value, httpClient)
    {
    }
    
    public OpenAIClient(Settings settings, HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        _httpClient.BaseAddress = new Uri($"https://api.openai.com/{ApiVersion}/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.ApiKey}");
        if (string.IsNullOrEmpty(settings.Organization) is false)
        {
            _httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", $"{settings.Organization}");
        }
    }

    /// <inheritdoc />
    public async Task<ListModelsResponse?> ListModels(CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<ListModelsResponse?>("models", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ModelResponse?> RetrieveModel(string id, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<ModelResponse?>($"models/{id}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateCompletionResponse>("completions", request, cancellationToken);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<CreateCompletionResponse> CreateCompletionAsStream(CreateCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        request.Stream = true;

        await foreach (var completion in CreateAsStream<CreateCompletionRequest, CreateCompletionResponse>("completions", request, cancellationToken))
        {
            yield return completion;
        }
    }

    /// <inheritdoc />
    public async Task<CreateChatCompletionResponse?> CreateChatCompletion(CreateChatCompletionRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateChatCompletionResponse>("chat/completions", request, cancellationToken);
    }

    /// <inheritdoc />
    public async IAsyncEnumerable<CreateChatCompletionResponse> CreateChatCompletionAsStream(CreateChatCompletionRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        request.Stream = true;

        await foreach (var chatCompletion in CreateAsStream<CreateChatCompletionRequest, CreateChatCompletionResponse>("chat/completions", request, cancellationToken))
        {
            yield return chatCompletion;
        }
    }

    /// <inheritdoc />
    public async Task<CreateEditResponse?> CreateEdit(CreateEditRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateEditResponse>("edits", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImage(CreateImageRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateImageResponse>("images/generations", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<CreateImageResponse>("images/edits", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<CreateImageResponse>("images/variations", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateEmbeddingsResponse?> CreateEmbeddings(CreateEmbeddingsRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateEmbeddingsResponse>("embeddings", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateAudioResponse?> CreateAudioTranscription(CreateAudioTranscriptionRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        multipartFormDataContent.AddOtherOptionsFrom(request);
        return await PostCreateAudioRequest("audio/transcriptions", request, multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateAudioResponse?> CreateAudioTranslation(CreateAudioTranslationRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await PostCreateAudioRequest("audio/translations", request, multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ListFilesResponse?> ListFiles(CancellationToken cancellationToken = default)
    {
        return await _httpClient.GetFromJsonAsync<ListFilesResponse?>("files", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FileResponse?> UploadFile(UploadFileRequest request, CancellationToken cancellationToken = default)
    {
        var multipartFormDataContent = request.ToMultipartFormDataContent();
        return await _httpClient.Post<FileResponse?>("files", multipartFormDataContent, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DeleteFileResponse?> DeleteFile(string fileId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Delete<DeleteFileResponse?>($"files/{fileId}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FileResponse?> RetrieveFile(string fileId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<FileResponse?>($"files/{fileId}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<string?> RetrieveFileContent(string fileId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<string?>($"files/{fileId}/content", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> CreateFineTune(CreateFineTuneRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<FineTuneResponse?>("fine-tunes", request, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ListFineTunesResponse?> ListFineTunes(CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<ListFineTunesResponse?>("fine-tunes", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> RetrieveFineTune(string fineTuneId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Get<FineTuneResponse?>($"fine-tunes/{fineTuneId}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<FineTuneResponse?> CancelFineTune(string fineTuneId, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<FineTuneResponse?>($"fine-tunes/{fineTuneId}/cancel", null, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ListFineTuneEventsResponse?> ListFineTuneEvents(string fineTuneId, bool? stream = null, CancellationToken cancellationToken = default)
    {
        var queryParameters = stream is not null ? $"?stream={stream}" : string.Empty;
        return await _httpClient.Get<ListFineTuneEventsResponse?>($"fine-tunes/{fineTuneId}/events{queryParameters}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<DeleteFineTunedModelResponse?> DeleteFineTunedModel(string model, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Delete<DeleteFineTunedModelResponse?>($"models/{model}", cancellationToken);
    }

    /// <inheritdoc />
    public async Task<CreateModerationResponse?> CreateModeration(CreateModerationRequest request, CancellationToken cancellationToken = default)
    {
        return await _httpClient.Post<CreateModerationResponse?>("moderations", request, cancellationToken);
    }

    private async IAsyncEnumerable<TResponse> CreateAsStream<TRequest, TResponse>(string requestUri, TRequest request, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        using var httpResponseMessage = await _httpClient.PostAsStream(requestUri, request!, cancellationToken);
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

            TResponse? createCompletionResponse;

            try
            {
                createCompletionResponse = JsonSerializer.Deserialize<TResponse>(line);
            }
            catch (Exception)
            {
                line += await streamReader.ReadToEndAsync(cancellationToken);
                createCompletionResponse = JsonSerializer.Deserialize<TResponse>(line);
            }

            if (createCompletionResponse is not null)
            {
                yield return createCompletionResponse;
            }
        }
    }

    private async Task<CreateAudioResponse?> PostCreateAudioRequest(string requestUri, CreateAudioRequestBase request, HttpContent multipartFormDataContent, CancellationToken cancellationToken)
    {
        if (request.HasJsonResponseFormat())
        {
            return await _httpClient.Post<CreateAudioResponse?>(requestUri, multipartFormDataContent, cancellationToken);
        }

        return new CreateAudioResponse
        {
            Text = await _httpClient.Post(requestUri, multipartFormDataContent, cancellationToken)
        };
    }
}
