using System.Net;

using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Domain.Books;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Errors;
using GoodReads.Application.Books.Models;

namespace GoodReads.Application.Books.GetBook;

public sealed class GetBookQueryHandler : IRequestHandler<GetBookQuery, Result<BookViewModel?>>
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public GetBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<Result<BookViewModel?>> Handle(GetBookQuery request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
            return Result.Fail<BookViewModel?>(new HttpStatusCodeError(BookErrors.NotFound, HttpStatusCode.NotFound));

        var userViewModel = _mapper.Map<BookViewModel>(book);

        return Result.Ok(userViewModel);
    }
}