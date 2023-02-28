using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cledev.OpenAI.Extensions;

internal static class HttpClientExtensions
{
    internal static async Task<T?> Get<T>(this HttpClient httpClient, string requestUri)
    {
        var response = await httpClient.GetAsync(requestUri);
        return await response.Content.ReadFromJsonAsync<T?>();
    }

    internal static async Task<T?> Post<T>(this HttpClient httpClient, string requestUri, object request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await httpClient.PostAsJsonAsync(requestUri, request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<T?>();
    }

    internal static async Task<T?> Post<T>(this HttpClient httpClient, string requestUri, HttpContent? content)
    {
        var response = await httpClient.PostAsync(requestUri, content);
        return await response.Content.ReadFromJsonAsync<T?>();
    }

    internal static async Task<HttpResponseMessage> PostAsStream(this HttpClient httpClient, string requestUri, object request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var jsonContent = JsonContent.Create(request, null, jsonSerializerOptions);

        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        httpRequestMessage.Content = jsonContent;

        return await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead);
    }

    internal static async Task<T?> Delete<T>(this HttpClient httpClient, string requestUri)
    {
        var response = await httpClient.DeleteAsync(requestUri);
        return await response.Content.ReadFromJsonAsync<T?>();
    }
}
