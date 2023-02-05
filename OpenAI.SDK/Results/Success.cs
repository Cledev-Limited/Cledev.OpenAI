namespace OpenAI.SDK.Results;

public record Success;

public record Success<TResult>
{
    public TResult? Result { get; init; }

    public Success()
    {
    }
    
    public Success(TResult result)
    {
        Result = result;
    }
}
