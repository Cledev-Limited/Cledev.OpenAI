namespace Cledev.OpenAI.Playground.Blazor;

public class WebClient
{
    private readonly HttpClient _httpClient;

    public WebClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetFromJsonAsync<T>(string requestUri)
    {
        var response = await _httpClient.GetAsync(requestUri);
        return await response.Content.ReadFromJsonAsync<T?>();
    }
}
