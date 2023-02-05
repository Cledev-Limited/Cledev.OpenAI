using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using OpenAI.SDK.V1.Contracts;

namespace OpenAI.SDK.V1;

public interface IOpenAIService
{
    Task<RetrieveModelsResponse?> RetrieveModels();
    Task<RetrieveModelsResponse.RetrieveModelsResponseData?> RetrieveModel(string id);
    Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request);
    Task<CreateCompletionResponse?> CreateCompletion(string prompt, CompletionsModel? model = null, int? maxTokens = null);
    Task<CreateEditResponse?> CreateEdit(CreateEditRequest request);
    Task<CreateEditResponse?> CreateEdit(string input, string instruction, EditsModel? model = null);
    Task<CreateImageResponse?> CreateImage(CreateImageRequest request);
    Task<CreateImageResponse?> CreateImage(string prompt, int? numberOfImagesToGenerate = null, ImageSize? size = null, ImageResponseFormat? responseFormat = null);
    Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request);
    Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request);
}

public class OpenAIService : IOpenAIService
{
    private const string ApiVersion = "v1";

    private readonly HttpClient _httpClient;

    public OpenAIService(HttpClient httpClient, IOptions<OpenAISettings> settings)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://api.openai.com/");
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {settings.Value.ApiKey}");
        if (string.IsNullOrEmpty(settings.Value.Organization) is false)
        {
            _httpClient.DefaultRequestHeaders.Add("OpenAI-Organization", $"{settings.Value.Organization}");
        }
    }

    public async Task<RetrieveModelsResponse?> RetrieveModels()
    {
        return await _httpClient.GetFromJsonAsync<RetrieveModelsResponse?>($"/{ApiVersion}/models");
    }

    public async Task<RetrieveModelsResponse.RetrieveModelsResponseData?> RetrieveModel(string id)
    {
        return await _httpClient.GetFromJsonAsync<RetrieveModelsResponse.RetrieveModelsResponseData?>($"/{ApiVersion}/models/{id}");
    }

    public async Task<CreateCompletionResponse?> CreateCompletion(CreateCompletionRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/completions", request);
        return await response.Content.ReadFromJsonAsync<CreateCompletionResponse?>();
    }

    public async Task<CreateCompletionResponse?> CreateCompletion(string prompt, CompletionsModel? model = null, int? maxTokens = null)
    {
        return await CreateCompletion(new CreateCompletionRequest
        {
            Model = (model ?? CompletionsModel.Ada).ToStringModel(),
            Prompt = prompt,
            MaxTokens = maxTokens ?? 16
        });
    }

    public async Task<CreateEditResponse?> CreateEdit(CreateEditRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/edits", request);
        return await response.Content.ReadFromJsonAsync<CreateEditResponse?>();
    }

    public async Task<CreateEditResponse?> CreateEdit(string input, string instruction, EditsModel? model = null)
    {
        return await CreateEdit(new CreateEditRequest
        {
            Model = (model ?? EditsModel.TextDavinciEditV1).ToStringModel(),
            Input = input,
            Instruction = instruction
        });
    }

    public async Task<CreateImageResponse?> CreateImage(CreateImageRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/images/generations", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<CreateImageResponse?>();
    }

    public async Task<CreateImageResponse?> CreateImage(string prompt, int? numberOfImagesToGenerate = null, ImageSize? size = null, ImageResponseFormat? responseFormat = null)
    {
        return await CreateImage(new CreateImageRequest
        {
            Prompt = prompt,
            NumberOfImagesToGenerate = numberOfImagesToGenerate ?? 1,
            ImageSize = (size ?? ImageSize.Size1024x1024).ToStringSize(),
            ResponseFormat = (responseFormat ?? ImageResponseFormat.Url).ToStringFormat()
        });
    }

    public async Task<CreateImageResponse?> CreateImageEdit(CreateImageEditRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/images/edits", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<CreateImageResponse?>();
    }

    public async Task<CreateImageResponse?> CreateImageVariation(CreateImageVariationRequest request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await _httpClient.PostAsJsonAsync($"/{ApiVersion}/images/variations", request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<CreateImageResponse?>();
    }
}
