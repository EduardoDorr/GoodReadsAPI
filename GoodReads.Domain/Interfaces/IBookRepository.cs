using GoodReads.Core.Interfaces;
using GoodReads.Domain.Books;

namespace GoodReads.Domain.Interfaces;

public interface IBookRepository : IReadableRepository<Book>, ICreatableRepository<Book>, IUpdatableRepository<Book>, IDeletableRepository<Book>
{
    Task<Book?> GetWithRatingsByIdAsync(int id);
}