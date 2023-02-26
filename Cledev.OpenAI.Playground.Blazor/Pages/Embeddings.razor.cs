using Cledev.OpenAI.V1.Contracts.Embeddings;
using Cledev.OpenAI.V1.Models;

namespace Cledev.OpenAI.Playground.Blazor.Pages;

public class EmbeddingsPage : PageComponentBase
{
    protected CreateEmbeddingsRequest Request { get; set; } = null!;
    protected CreateEmbeddingsResponse? Response { get; set; }

    public IList<string> EmbeddingModels { get; set; } = new List<string>();

    protected override void OnInitialized()
    {
        Request = new CreateEmbeddingsRequest
        {
            Model = EmbeddingsModel.TextEmbeddingAdaV2.ToStringModel()
        };

        EmbeddingModels = Enum.GetValues(typeof(EmbeddingsModel)).Cast<EmbeddingsModel>().Select(x => x.ToStringModel()).ToList();
    }

    protected async Task OnSubmitAsync()
    {
        IsLoading = true;
        Response = null;

        Response = await OpenAIClient.CreateEmbeddings(Request);
        Error = Response?.Error;

        IsLoading = false;
    }
}
