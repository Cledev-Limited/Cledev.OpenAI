using OneOf;

namespace OpenAI.NET.SDK.Models;

public sealed class Result<TResponse> : OneOfBase<TResponse, Error>
{
    private Result(OneOf<TResponse, Error> input) : base(input) { }

    public static implicit operator Result<TResponse>(TResponse response) => new(response);
    public static implicit operator Result<TResponse>(Error error) => new(error);

    public bool IsSuccess => IsT0;
    public bool IsError => IsT1;

    public TResponse? Response => AsT0;
    public Error Error => AsT1;

    public bool TryPickSuccess(out TResponse response, out Error error) => TryPickT0(out response, out error);
    public bool TryPickError(out Error error, out TResponse response) => TryPickT1(out error, out response);
}
