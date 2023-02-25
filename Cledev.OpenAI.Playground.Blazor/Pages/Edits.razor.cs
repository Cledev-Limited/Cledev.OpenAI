using Cledev.OpenAI.V1.Contracts.Edits;
using Cledev.OpenAI.V1.Models;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class EditsPage : PageComponentBase
{
    protected CreateEditRequest Request { get; set; } = null!;
    protected CreateEditResponse? Response { get; set; }

    public IList<string> EditModels { get; set; } = new List<string>();

    protected override void OnInitialized()
    {
        Request = new CreateEditRequest
        {
            Model = EditsModel.TextDavinciEditV1.ToStringModel(),
            Instruction = string.Empty
        };

        EditModels = Enum.GetValues(typeof(EditsModel)).Cast<EditsModel>().Select(x => x.ToStringModel()).ToList();
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;
        Response = null;

        Response = await OpenAIClient.CreateEdit(Request);
        Error = Response?.Error;

        IsLoading = false;
    }
}
