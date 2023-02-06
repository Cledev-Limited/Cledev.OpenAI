using Microsoft.AspNetCore.Components;
using OpenAI.NET.SDK.V1;

namespace OpenAI.NET.Playground.Web.Pages
{
    public class IndexPage : ComponentBase
    {
        [Inject] public IOpenAIClient OpenAIClient { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var test = await OpenAIClient.CreateCompletion(CompletionsModel.Ada, "Say something nice");
        }
    }
}
