using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.ExternalBooksApi.Models;
using GoodReads.Application.ExternalBooksApi.Interfaces;

namespace GoodReads.Application.ExternalBooksApi.GetBooksByTitle;

public sealed class getBooksByTitleRequestHandler : IRequestHandler<GetBooksByTitleRequest, Result<ExternalBooksApiViewModel?>>
{
    private readonly IExternalBookApi _externalBooksApi;

    public getBooksByTitleRequestHandler(IExternalBookApi externalBooksApi)
    {
        _externalBooksApi = externalBooksApi;
    }

    public async Task<Result<ExternalBooksApiViewModel?>> Handle(GetBooksByTitleRequest request, CancellationToken cancellationToken)
    {
        var result = await _externalBooksApi.GetBooksByTitleAsync(request.Title);

        return result;
    }
}