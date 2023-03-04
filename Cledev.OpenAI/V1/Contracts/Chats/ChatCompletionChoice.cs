using System.Text.Json.Serialization;

namespace Cledev.OpenAI.V1.Contracts.Chats;

public record ChatCompletionChoice
{
    [JsonPropertyName("delta")]
    public ChatCompletionMessage? Delta
    {
        get => Message;
        set => Message = value;
    }

    [JsonPropertyName("message")]
    public ChatCompletionMessage? Message { get; set; }

    [JsonPropertyName("index")]
    public int Index { get; set; }

    [JsonPropertyName("finish_reason")]
    public string FinishReason { get; set; } = null!;
}
