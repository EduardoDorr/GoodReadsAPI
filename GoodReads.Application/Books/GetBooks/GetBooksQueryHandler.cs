using MediatR;
using AutoMapper;

using GoodReads.Core.Models;
using GoodReads.Core.Results;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Books.Models;

namespace GoodReads.Application.Books.GetBooks;

public sealed class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, Result<PaginationResult<BookViewModel>>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<Result<PaginationResult<BookViewModel>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var paginationBooks = await _bookRepository.GetAllAsync(request.Page, request.PageSize);

        var booksViewModel = _mapper.Map<List<BookViewModel>>(paginationBooks.Data);

        var paginationBooksViewModel =
            new PaginationResult<BookViewModel>
            (
                paginationBooks.Page,
                paginationBooks.PageSize,
                paginationBooks.TotalCount,
                paginationBooks.TotalPages,
                booksViewModel
            );

        return Result.Ok(paginationBooksViewModel);
    }
}
