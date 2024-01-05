using GoodReads.Domain.DomainResults.Errors;

namespace GoodReads.Domain.DomainResults;

public abstract class ResultBase
{
    public IReadOnlyList<IError> Errors => _errors.ToList().AsReadOnly();

    protected readonly List<IError> _errors = [];

    public bool Success { get; protected set; }
}