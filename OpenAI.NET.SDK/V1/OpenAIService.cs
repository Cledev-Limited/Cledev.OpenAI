using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using OpenAI.NET.SDK.V1.Contracts;

namespace OpenAI.NET.SDK.V1;

public class OpenAIService : IOpenAIService
{
    private const string ApiVersion = "v1";

    private readonly HttpClient _httpClient;

    public OpenAIService(HttpClient httpClient, IOptions<OpenAISettings> options)
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
    public async Task<RetrieveModelsResponse?> RetrieveModels()
    {
        return await _httpClient.GetFromJsonAsync<RetrieveModelsResponse?>($"/{ApiVersion}/models");
    }

    /// <inheritdoc />
    public async Task<RetrieveModelsResponse.RetrieveModelsResponseData?> RetrieveModel(string id)
    {
        return await _httpClient.GetFromJsonAsync<RetrieveModelsResponse.RetrieveModelsResponseData?>($"/{ApiVersion}/models/{id}");
    }

    /// <inheritdoc />
    public async Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/completions", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<CreateCompletionResponse?>();
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
    public async Task<CreateEditResponse?> CreateEdit(CreateEditRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/edits", request);
        return await response.Content.ReadFromJsonAsync<CreateEditResponse?>();
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
    public async Task<CreateImageResponse?> CreateImage(CreateImageRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/images/generations", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<CreateImageResponse?>();
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
    public async Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/images/edits", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<CreateImageResponse?>();
    }

    /// <inheritdoc />
    public async Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/images/variations", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<CreateImageResponse?>();
    }
}
