using Cledev.OpenAI.V1.Contracts.Models;
using Microsoft.AspNetCore.Components;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class ModelsPage : PageComponentBase
{
    protected string? ModelId { get; set; }
    protected bool SearchCompleted { get; set; }

    public List<ModelResponse> Models { get; set; } = new();

    protected void OnValueChanged(ChangeEventArgs e)
    {
        ModelId = e.Value?.ToString();
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;
        SearchCompleted = false;
        Models.Clear();

        if (string.IsNullOrEmpty(ModelId))
        {
            var response = await OpenAIClient.ListModels();
            Error = response?.Error;
            if (response is not null)
            {
                Models.AddRange(response.Data);
            }
        }
        else
        {
            var response = await OpenAIClient.RetrieveModel(ModelId);
            Error = response?.Error;
            if (response is not null)
            {
                Models.Add(response);
            }
        }

        IsLoading = false;
        SearchCompleted = true;
    }
}
