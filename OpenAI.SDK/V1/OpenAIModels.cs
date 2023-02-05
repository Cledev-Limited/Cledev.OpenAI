namespace OpenAI.SDK.V1;

public enum CompletionsModel
{
    Ada,
    Babbage,
    Curie,
    Davinci,
    TextAdaV1,
    TextBabbageV1,
    TextCurieV1,
    TextDavinciV1,
    TextDavinciV2,
    TextDavinciV3,
    CodeCushmanV1,
    CodeDavinciV2,
    CurieInstructBeta,
    DavinciInstructBeta
}

public enum EditsModel
{
    TextDavinciEditV1,
    CodeDavinciEditV1
}

public enum EmbeddingsModel
{
    TextEmbeddingAdaV2
}

public static class OpenAIModelsExtensions
{
    public static string ToStringModel(this CompletionsModel completionsModel)
    {
        return completionsModel switch
        {
            CompletionsModel.Ada => "ada",
            CompletionsModel.Babbage => "babbage",
            CompletionsModel.Curie => "curie",
            CompletionsModel.Davinci => "davinci",
            CompletionsModel.TextAdaV1 => "text-ada-001",
            CompletionsModel.TextBabbageV1 => "text-baggage-001",
            CompletionsModel.TextCurieV1 => "text-curie-001",
            CompletionsModel.TextDavinciV1 => "text-davinci-001",
            CompletionsModel.TextDavinciV2 => "text-davinci-002",
            CompletionsModel.TextDavinciV3 => "text-davinci-003",
            CompletionsModel.CodeCushmanV1 => "code-cushman-001",
            CompletionsModel.CodeDavinciV2 => "code-davinci-002",
            CompletionsModel.CurieInstructBeta => "curie-instruct-beta",
            CompletionsModel.DavinciInstructBeta => "davinci-instruct-beta",
            _ => throw new ArgumentOutOfRangeException(nameof(completionsModel), completionsModel, null)
        };
    }

    public static string ToStringModel(this EditsModel editsModel)
    {
        return editsModel switch
        {
            EditsModel.CodeDavinciEditV1 => "code-davinci-edit-001",
            EditsModel.TextDavinciEditV1 => "text-davinci-edit-001",
            _ => throw new ArgumentOutOfRangeException(nameof(editsModel), editsModel, null)
        };
    }

    public static string ToStringModel(this EmbeddingsModel embeddingsModel)
    {
        return embeddingsModel switch
        {
            EmbeddingsModel.TextEmbeddingAdaV2 => "text-embedding-ada-002",
            _ => throw new ArgumentOutOfRangeException(nameof(embeddingsModel), embeddingsModel, null)
        };
    }
}
