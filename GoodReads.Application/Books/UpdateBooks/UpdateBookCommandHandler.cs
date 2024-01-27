using System.Net;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Books;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Errors;
using GoodReads.Application.Books.UpdateBooks;

namespace GoodReads.Application.Users.UpdateUser;

public sealed class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public UpdateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<Result> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
            return Result.Fail(new HttpStatusCodeError(BookErrors.NotFound, HttpStatusCode.NotFound));

        book.Update(request.Title, request.Description, request.Isbn,
                    request.Author, request.Publisher, request.Genre,
                    request.PublicationYear, request.PrintLength, request.CoverImage, request.Active);

        _bookRepository.Update(book);

        var updated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!updated)
            return Result.Fail(BookErrors.CannotBeUpdated);

        return Result.Ok();
    }
}