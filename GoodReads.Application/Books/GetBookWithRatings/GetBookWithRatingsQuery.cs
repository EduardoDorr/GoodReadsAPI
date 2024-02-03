using MediatR;

using GoodReads.Core.Results;
using GoodReads.Application.Books.Models;

namespace GoodReads.Application.Books.GetBookWithRatings;

public sealed record GetBookWithRatingsQuery(int Id) : IRequest<Result<BookWithRatingsViewModel?>>;