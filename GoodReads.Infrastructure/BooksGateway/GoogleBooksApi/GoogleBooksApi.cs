using Microsoft.Extensions.Configuration;

using GoodReads.Core.Results;
using GoodReads.Core.Results.Errors;
using GoodReads.Application.ExternalBooksApi.Models;
using GoodReads.Application.ExternalBooksApi.Interfaces;

namespace GoodReads.Infrastructure.BooksGateway.GoogleBooksApi;

public class GoogleBooksApi : IExternalBookApi
{
    private readonly IGoogleBooksApi _googleBooksApi;
    private readonly string _apiKey;

    public GoogleBooksApi(IGoogleBooksApi googleBooksApi, IConfiguration configuration)
    {
        _googleBooksApi = googleBooksApi;
        _apiKey = configuration["GoogleBooks:ApiKey"];
    }

    public async Task<Result<ExternalBooksApiViewModel?>> GetBookByIsbnAsync(string isbn)
    {
        if (string.IsNullOrEmpty(_apiKey))
            Result.Fail<ExternalBooksApiViewModel?>(new Error("GoogleBooks.ApiKeyMissing", "The api key is missing"));

        var googleBooksDto = await _googleBooksApi.GetBookByIsbnAsync(isbn, _apiKey);

        return Result.Ok(googleBooksDto.ToViewModel());
    }

    public async Task<Result<ExternalBooksApiViewModel?>> GetBooksByTitleAsync(string title)
    {
        if (string.IsNullOrEmpty(_apiKey))
            Result.Fail<ExternalBooksApiViewModel?>(new Error("GoogleBooks.ApiKeyMissing", "The api key is missing"));

        var googleBooksDto = await _googleBooksApi.GetBooksByTitleAsync(title, _apiKey);

        return Result.Ok(googleBooksDto.ToViewModel());
    }
}