namespace Cledev.OpenAI.V1.Enums;

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

public enum FineTuningModel
{
    Ada,
    Babbage,
    Curie,
    Davinci
}

public enum ModerationModel
{
    TextModerationStable,
    TextModerationLatest
}

public enum ChatModel
{
    Gpt35Turbo,
    Gpt35Turbo0301
}

public enum AudioModel
{
    Whisper1
}

public static class ModelEnumsExtensions
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

    public static string ToStringModel(this FineTuningModel fineTuningModel)
    {
        return fineTuningModel switch
        {
            FineTuningModel.Ada => "ada",
            FineTuningModel.Babbage => "babbage",
            FineTuningModel.Curie => "curie",
            FineTuningModel.Davinci => "davinci",
            _ => throw new ArgumentOutOfRangeException(nameof(fineTuningModel), fineTuningModel, null)
        };
    }

    public static string ToStringModel(this ModerationModel moderationModel)
    {
        return moderationModel switch
        {
            ModerationModel.TextModerationStable => "text-moderation-stable",
            ModerationModel.TextModerationLatest => "text-moderation-latest",
            _ => throw new ArgumentOutOfRangeException(nameof(moderationModel), moderationModel, null)
        };
    }

    public static string ToStringModel(this ChatModel chatModel)
    {
        return chatModel switch
        {
            ChatModel.Gpt35Turbo => "gpt-3.5-turbo",
            ChatModel.Gpt35Turbo0301 => "gpt-3.5-turbo-0301",
            _ => throw new ArgumentOutOfRangeException(nameof(chatModel), chatModel, null)
        };
    }

    public static string ToStringModel(this AudioModel audioModel)
    {
        return audioModel switch
        {
            AudioModel.Whisper1 => "whisper-1",
            _ => throw new ArgumentOutOfRangeException(nameof(audioModel), audioModel, null)
        };
    }
}
