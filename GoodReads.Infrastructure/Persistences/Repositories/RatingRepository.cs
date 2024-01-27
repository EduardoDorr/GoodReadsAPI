using Microsoft.EntityFrameworkCore;

using GoodReads.Core.Models;
using GoodReads.Domain.Ratings;
using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Persistences.Data;
using GoodReads.Infrastructure.Persistences.Extensions;

namespace GoodReads.Infrastructure.Persistences.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly GoodReadsDbContext _dbContext;

    public RatingRepository(GoodReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<Rating>> GetAllAsync(int page = 1, int pageSize = 10)
    {
        IQueryable<Rating> books = _dbContext.Ratings;

        return await books.GetPaged(page, pageSize);
    }

    public async Task<Rating?> GetByIdAsync(int id)
    {
        return await _dbContext.Ratings.SingleOrDefaultAsync(r => r.Id == id);
    }

    public void Create(Rating rating)
    {
        _dbContext.Ratings.Add(rating);
    }

    public void Update(Rating rating)
    {
        _dbContext.Ratings.Update(rating);
    }

    public void Delete(Rating rating)
    {
        _dbContext.Ratings.Remove(rating);
    }
}