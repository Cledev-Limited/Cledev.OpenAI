using Microsoft.AspNetCore.Components;
using OpenAI.NET.SDK.V1;

namespace OpenAI.NET.Playground.Web.Pages
{
    public class IndexPage : ComponentBase
    {
        [Inject] public IOpenAIService OpenAIService { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            var test = await OpenAIService.CreateCompletion(CompletionsModel.Ada, "Say something nice");
        }
    }
}
