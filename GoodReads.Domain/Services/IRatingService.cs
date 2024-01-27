using GoodReads.Core.Results;
using GoodReads.Domain.Books;
using GoodReads.Domain.Ratings;

namespace GoodReads.Domain.Services;

public interface IRatingService
{
    Result Evaluate(Rating rating, Book book);
}