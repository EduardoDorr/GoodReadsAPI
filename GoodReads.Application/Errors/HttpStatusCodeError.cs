using System.Net;

using GoodReads.Core.Results.Errors;

namespace GoodReads.Application.Errors;

public record HttpStatusCodeError(string Code, string Message, HttpStatusCode StatusCode) : IError
{
    public HttpStatusCodeError(Error error, HttpStatusCode StatusCode)
        : this(error.Code, error.Message, StatusCode) { }
}