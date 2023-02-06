using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace OpenAI.NET.SDK.Extensions;

internal static class HttpClientExtensions
{
    internal static async Task<T?> Post<T>(this HttpClient httpClient, string requestUri, object request)
    {
        var jsonSerializerOptions = new JsonSerializerOptions { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault };
        var response = await httpClient.PostAsJsonAsync(requestUri, request, jsonSerializerOptions);
        return await response.Content.ReadFromJsonAsync<T?>();
    }

    internal static async Task<T?> Post<T>(this HttpClient httpClient, string requestUri, HttpContent content)
    {
        var response = await httpClient.PostAsync(requestUri, content);
        return await response.Content.ReadFromJsonAsync<T?>();
    }
}
