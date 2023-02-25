using Cledev.OpenAI.V1.Contracts.Models;
using Microsoft.AspNetCore.Components;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class ModelsPage : PageComponentBase
{
    protected string? ModelId { get; set; }
    protected bool SearchCompleted { get; set; }

    protected ListModelsResponse? ListModelsResponse { get; set; }
    protected RetrieveModelResponse? RetrieveModelResponse { get; set; }

    protected void OnValueChanged(ChangeEventArgs e)
    {
        ModelId = e.Value?.ToString();
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;
        SearchCompleted = false;

        ListModelsResponse = null;
        RetrieveModelResponse = null;

        if (string.IsNullOrEmpty(ModelId))
        {
            ListModelsResponse = await OpenAIClient.ListModels();
            Error = ListModelsResponse?.Error;
        }
        else
        {
            RetrieveModelResponse = await OpenAIClient.RetrieveModel(ModelId);
            Error = RetrieveModelResponse?.Error;
        }

        IsLoading = false;
        SearchCompleted = true;
    }
}
