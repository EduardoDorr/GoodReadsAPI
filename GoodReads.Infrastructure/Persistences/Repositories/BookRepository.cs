using Microsoft.EntityFrameworkCore;

using GoodReads.Core.Models;
using GoodReads.Domain.Books;
using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Persistences.Data;
using GoodReads.Infrastructure.Persistences.Extensions;

namespace GoodReads.Infrastructure.Persistences.Repositories;

public class BookRepository : IBookRepository
{
    private readonly GoodReadsDbContext _dbContext;

    public BookRepository(GoodReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Book>> GetAllAsync(int page = 1, int pageSize = 10)
    {
        IQueryable<Book> books = _dbContext.Books;

        return await books.GetPaged(page, pageSize);
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        return await _dbContext.Books.SingleOrDefaultAsync(book => book.Id == id);
    }

    public Task<Book?> GetWithRatingsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(Book book)
    {
        _dbContext.Books.Add(book);
    }

    public void Update(Book book)
    {
        _dbContext.Books.Update(book);
    }

    public void Delete(Book book)
    {
        _dbContext.Books.Remove(book);
    }
}