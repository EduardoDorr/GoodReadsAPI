using GoodReads.Domain.DomainResults.Errors;

namespace GoodReads.Domain.DomainResults;

public class Result : ResultBase
{
    protected Result()
    {
        Success = true;
    }

    protected Result(string errorMessage)
    {
        Success = false;
        _errors.Add(new Error(errorMessage, errorMessage));
    }

    protected Result(IError error)
    {
        Success = false;
        _errors.Add(error);
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors is null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        Success = false;
        _errors.AddRange(errors);
    }

    public static Result Ok() => new Result();
    public static Result Fail(string errorMessage) => new Result(errorMessage);
    public static Result Fail(IError error) => new Result(error);
    public static Result Fail(IEnumerable<IError> errors) => new Result(errors);

    //public static implicit operator Result(string errorMessage) => new Result(errorMessage);
    //public static implicit operator Result(IError error) => new Result(error);
    //public static implicit operator Result(IEnumerable<IError> errors) => new Result(errors);
}

public class Result<T> : ResultBase
{
    public T? Value => _value;

    private T? _value;

    protected Result(T value)
    {
        Success = true;
        _value = value;
    }

    protected Result(string errorMessage)
    {
        Success = false;
        _errors.Add(new Error(errorMessage, errorMessage));
    }

    protected Result(IError error)
    {
        Success = false;
        _errors.Add(error);
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors is null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        Success = false;
        _errors.AddRange(errors);
    }

    public static Result<T> Ok(T value) => new Result<T>(value);
    public static Result<T> Fail(string errorMessage) => new Result<T>(errorMessage);
    public static Result<T> Fail(IError error) => new Result<T>(error);
    public static Result<T> Fail(IEnumerable<IError> errors) => new Result<T>(errors);

    //public static implicit operator Result<T>(T value) => new Result<T>(value);
    //public static implicit operator Result<T>(IError error) => new Result<T>(error);
    //public static implicit operator Result<T>(IEnumerable<IError> errors) => new Result<T>(errors);
}