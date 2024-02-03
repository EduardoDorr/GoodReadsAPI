using GoodReads.Core.Results;
using GoodReads.Application.ExternalBooksApi.Models;

namespace GoodReads.Application.ExternalBooksApi.Interfaces;

public interface IExternalBookApi
{
    Task<Result<ExternalBooksApiViewModel?>> GetBookByIsbnAsync(string isbn);
    Task<Result<ExternalBooksApiViewModel?>> GetBooksByTitleAsync(string isbn);
}