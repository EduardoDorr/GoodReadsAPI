using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.ExternalBooksApi.Models;
using GoodReads.Application.ExternalBooksApi.Interfaces;

namespace GoodReads.Application.ExternalBooksApi.GetBookByIsbn;

public sealed class GetBookByIsbnRequestHandler : IRequestHandler<GetBookByIsbnRequest, Result<ExternalBooksApiViewModel?>>
{
    private readonly IExternalBookApi _externalBooksApi;

    public GetBookByIsbnRequestHandler(IExternalBookApi externalBooksApi)
    {
        _externalBooksApi = externalBooksApi;
    }

    public async Task<Result<ExternalBooksApiViewModel?>> Handle(GetBookByIsbnRequest request, CancellationToken cancellationToken)
    {
        var result = await _externalBooksApi.GetBookByIsbnAsync(request.Isbn);

        return result;
    }
}