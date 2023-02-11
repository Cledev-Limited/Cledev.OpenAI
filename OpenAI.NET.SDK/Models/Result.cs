using OneOf;

namespace OpenAI.NET.SDK.Models;

public sealed class Result<TResult> : OneOfBase<Success<TResult>, Failure>
{
    private Result(OneOf<Success<TResult>, Failure> input) : base(input) { }

    public static implicit operator Result<TResult>(Success<TResult> success) => new(success);
    public static implicit operator Result<TResult>(Failure failure) => new(failure);
    public static implicit operator Result<TResult>(TResult result) => new(new Success<TResult>(result));

    public bool IsSuccess => IsT0;
    public bool IsFailure => IsT1;

    public Success<TResult> Success => AsT0;
    public Failure Failure => AsT1;

    public new TResult? Value => AsT0.Result;

    public bool TryPickSuccess(out Success<TResult> success, out Failure failure) => TryPickT0(out success, out failure);
    public bool TryPickFailure(out Failure failure, out Success<TResult> success) => TryPickT1(out failure, out success);
}
