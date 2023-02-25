using Cledev.OpenAI.V1.Contracts.Completions;
using Cledev.OpenAI.V1.Models;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class CompletionsPage : PageComponentBase
{
    protected CreateCompletionRequest Request { get; set; } = null!;
    protected CreateCompletionResponse? Response { get; set; }

    public IList<string> CompletionModels { get; set; } = new List<string>();

    protected override void OnInitialized()
    {
        Request = new CreateCompletionRequest
        {
            Model = CompletionsModel.TextDavinciV3.ToStringModel()
        };

        CompletionModels = Enum.GetValues(typeof(CompletionsModel)).Cast<CompletionsModel>().Select(x => x.ToStringModel()).ToList();
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
