using GoodReads.Domain.Entities;
using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Data;

namespace GoodReads.Infrastructure.Repositories;

public class RatingRepository : IRatingRepository
{
    private readonly GoodReadsDbContext _dbContext;

    public RatingRepository(GoodReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<Rating>> GetAllAsync(int skip = 0, int take = 50)
    {
        throw new NotImplementedException();
    }

    public Task<Rating?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(Rating entity)
    {
        throw new NotImplementedException();
    }

    public void Update(Rating entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(Rating entity)
    {
        throw new NotImplementedException();
    }
}