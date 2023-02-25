using Cledev.OpenAI.V1;
using Cledev.OpenAI.V1.Contracts;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public abstract class PageComponentBase : ComponentBase
{
    [Inject] public IOpenAIClient OpenAIClient { get; set; } = null!;
    [Inject] public IJSRuntime JsRuntime { get; set; } = null!;

    protected bool IsLoading { get; set; }

    protected Error? Error { get; set; }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await JsRuntime.InvokeVoidAsync("addTooltips");
        }
    }
}
