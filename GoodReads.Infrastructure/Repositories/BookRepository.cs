using GoodReads.Domain.Entities;
using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Data;

namespace GoodReads.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly GoodReadsDbContext _dbContext;

    public BookRepository(GoodReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Book>> GetAllAsync(int skip = 0, int take = 50)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<Book?> GetWithRatingsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(Book entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Book entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Book entity)
    {
        throw new NotImplementedException();
    }
}