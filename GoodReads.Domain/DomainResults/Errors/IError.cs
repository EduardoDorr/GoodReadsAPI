namespace GoodReads.Domain.DomainResults.Errors;

public interface IError
{
    string Code { get; init; }
    string Message { get; init; }
}