using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Domain.Books;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Books.Models;

namespace GoodReads.Application.Books.GetBookWithRatings;

public sealed class GetBookWithRatingsQueryHandler : IRequestHandler<GetBookWithRatingsQuery, Result<BookWithRatingsViewModel?>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookWithRatingsQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<Result<BookWithRatingsViewModel?>> Handle(GetBookWithRatingsQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetWithRatingsByIdAsync(request.Id);

        if (book is null)
            return Result.Fail<BookWithRatingsViewModel?>(BookErrors.NotFound);

        var bookViewModel = _mapper.Map<BookWithRatingsViewModel>(book);

        return Result.Ok(bookViewModel);
    }
}