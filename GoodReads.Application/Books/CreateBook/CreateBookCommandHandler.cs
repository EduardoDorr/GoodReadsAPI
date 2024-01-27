using MediatR;
using AutoMapper;

using GoodReads.Core.Results;
using GoodReads.Core.Interfaces;
using GoodReads.Domain.Books;
using GoodReads.Domain.Interfaces;

namespace GoodReads.Application.Books.CreateBook;

internal sealed class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Result<int>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public CreateBookCommandHandler(IUnitOfWork unitOfWork, IBookRepository bookRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<Result<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = _mapper.Map<Book>(request);

        _bookRepository.Create(book);

        var created = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0;

        if (!created)
            return Result.Fail<int>(BookErrors.CannotBeCreated);

        return Result.Ok(book.Id);
    }
}