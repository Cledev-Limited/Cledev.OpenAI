using System.Net.Http.Json;
using Microsoft.Extensions.Options;
using OpenAI.NET.SDK.Extensions;
using OpenAI.NET.SDK.V1.Contracts.Completions;
using OpenAI.NET.SDK.V1.Contracts.Edits;
using OpenAI.NET.SDK.V1.Contracts.Embeddings;
using OpenAI.NET.SDK.V1.Contracts.Files;
using OpenAI.NET.SDK.V1.Contracts.Images;
using OpenAI.NET.SDK.V1.Contracts.Models;

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
        return await _httpClient.GetFromJsonAsync<ListModelsResponse?>($"/{ApiVersion}/models");
    }

    /// <inheritdoc />
    public async Task<RetrieveModelResponse?> RetrieveModel(string id)
    {
        return await _httpClient.GetFromJsonAsync<RetrieveModelResponse?>($"/{ApiVersion}/models/{id}");
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateCompletion(CompletionsModel model, string? prompt = null, int? maxTokens = null)
    {
        return await CreateCompletion(new CreateCompletionRequest
        {
            Model = model.ToStringModel(),
            Prompt = prompt,
            MaxTokens = maxTokens ?? 16
        });
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request)
    {
        return await _httpClient.Post<CreateCompletionResponse>($"/{ApiVersion}/completions", request);
    }

    /// <inheritdoc />
    public async Task<CreateEditResponse?> CreateEdit(EditsModel model, string? input = null, string? instruction = null)
    {
        return await CreateEdit(new CreateEditRequest
        {
            Model = model.ToStringModel(),
            Input = input,
            Instruction = instruction
        });
    }

    /// <inheritdoc />
    public async Task<CreateEditResponse?> CreateEdit(CreateEditRequest request)
    {
        return await _httpClient.Post<CreateEditResponse>($"/{ApiVersion}/edits", request);
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImage(string prompt, int? numberOfImagesToGenerate = null, ImageSize? size = null, ImageResponseFormat? responseFormat = null)
    {
        return await CreateImage(new CreateImageRequest
        {
            Prompt = prompt,
            N = numberOfImagesToGenerate ?? 1,
            Size = (size ?? ImageSize.Size1024x1024).ToStringSize(),
            ResponseFormat = (responseFormat ?? ImageResponseFormat.Url).ToStringFormat()
        });
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
}
