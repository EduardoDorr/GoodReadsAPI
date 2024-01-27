using System.Net;

using MediatR;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Books;
using GoodReads.Domain.Interfaces;
using GoodReads.Application.Errors;

namespace GoodReads.Application.Books.DeleteBook;

public sealed class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;

    public DeleteBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
    }

    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await _bookRepository.GetByIdAsync(request.Id);

        if (book is null)
            return Result.Fail(new HttpStatusCodeError(BookErrors.NotFound, HttpStatusCode.NotFound));

        book.Deactivate();

        _bookRepository.Update(book);

        var updated = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!updated)
            return Result.Fail(BookErrors.CannotBeDeleted);

        return Result.Ok();
    }
}