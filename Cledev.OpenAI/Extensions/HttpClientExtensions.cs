using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Cledev.OpenAI.Extensions;

internal static class HttpClientExtensions
{
    internal static async Task<T?> Get<T>(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync(requestUri, cancellationToken);
        return await response.Content.ReadFromJsonAsync<T?>(cancellationToken: cancellationToken);
    }

    internal static async Task<T?> Post<T>(this HttpClient httpClient, string requestUri, object request, CancellationToken cancellationToken = default)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await httpClient.PostAsJsonAsync(requestUri, request, jsonSerializerOptions, cancellationToken);
        return await response.Content.ReadFromJsonAsync<T?>(cancellationToken: cancellationToken);
    }

    internal static async Task<T?> Post<T>(this HttpClient httpClient, string requestUri, HttpContent? content, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync(requestUri, content, cancellationToken);
        return await response.Content.ReadFromJsonAsync<T?>(cancellationToken: cancellationToken);
    }

    internal static async Task<string> Post(this HttpClient httpClient, string requestUri, HttpContent? content, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.PostAsync(requestUri, content, cancellationToken);
        return await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
    }

    internal static async Task<HttpResponseMessage> PostAsStream(this HttpClient httpClient, string requestUri, object request, CancellationToken cancellationToken = default)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var jsonContent = JsonContent.Create(request, null, jsonSerializerOptions);

        using var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
        httpRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("text/event-stream"));
        httpRequestMessage.Content = jsonContent;

        return await httpClient.SendAsync(httpRequestMessage, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
    }

    internal static async Task<T?> Delete<T>(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.DeleteAsync(requestUri, cancellationToken);
        return await response.Content.ReadFromJsonAsync<T?>(cancellationToken: cancellationToken);
    }
}
