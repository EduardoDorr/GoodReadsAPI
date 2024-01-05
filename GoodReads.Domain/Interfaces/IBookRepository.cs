using GoodReads.Domain.Entities;

namespace GoodReads.Domain.Interfaces;

public interface IBookRepository : IBaseRepository<Book>
{
    Task<Book?> GetWithRatingsByIdAsync(int id);
}