using Cledev.OpenAI.V1;
using Cledev.OpenAI.V1.Contracts.Completions;
using Cledev.OpenAI.V1.Models;
using Microsoft.AspNetCore.Components;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class CompletionsPage : ComponentBase
{
    [Inject] public IOpenAIClient OpenAIClient { get; set; } = null!;

    protected bool IsLoading { get; set; }

    protected CompletionsPageModel Model { get; set; } = null!;
    protected CreateCompletionResponse? Response { get; set; }

    protected override void OnInitialized()
    {
        Model = new CompletionsPageModel
        {
            Request = new CreateCompletionRequest
            {
                Model = CompletionsModel.TextDavinciV3.ToStringModel()
            },
            CompletionModels = Enum.GetValues(typeof(CompletionsModel)).Cast<CompletionsModel>().Select(x => x.ToStringModel()).ToList()
        };
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;
        Response = null;
        Response = await OpenAIClient.CreateCompletion(Model.Request);
        IsLoading = false;

        if (Response is null)
        {
            // TODO: Display error message
        }
    }

    protected class CompletionsPageModel
    {
        public required CreateCompletionRequest Request { get; set; }
        public IList<string> CompletionModels { get; set; } = new List<string>();
    }
}