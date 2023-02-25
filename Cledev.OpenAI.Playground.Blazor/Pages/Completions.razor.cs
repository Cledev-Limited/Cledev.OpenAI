using Cledev.OpenAI.V1;
using Cledev.OpenAI.V1.Contracts;
using Cledev.OpenAI.V1.Contracts.Completions;
using Cledev.OpenAI.V1.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class CompletionsPage : ComponentBase
{
    [Inject] public IOpenAIClient OpenAIClient { get; set; } = null!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    protected bool IsLoading { get; set; }

    protected CreateCompletionRequest Request { get; set; } = null!;
    protected CreateCompletionResponse? Response { get; set; }
    protected Error? Error { get; set; }

    public IList<string> CompletionModels { get; set; } = new List<string>();

    protected override void OnInitialized()
    {
        Request = new CreateCompletionRequest
        {
            Model = CompletionsModel.TextDavinciV3.ToStringModel()
        };

        CompletionModels = Enum.GetValues(typeof(CompletionsModel)).Cast<CompletionsModel>().Select(x => x.ToStringModel()).ToList();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsRuntime.InvokeVoidAsync("addTooltips");
        }
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;
        Response = null;

        if (Request.Stream is true)
        {
            var completions = OpenAIClient.CreateCompletionAsStream(Request);

            await foreach (var completion in completions)
            {
                if (Response is null)
                {
                    Response = completion;
                }
                else
                {
                    Response.Choices[0].Text += completion.Choices[0].Text;
                }

                StateHasChanged();
            }
        }
        else
        {
            Response = await OpenAIClient.CreateCompletion(Request);
            Error = Response?.Error;
        }

        IsLoading = false;
    }
}
