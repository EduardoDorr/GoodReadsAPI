using GoodReads.Domain.Entities;
using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Data;

namespace GoodReads.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GoodReadsDbContext _dbContext;

    public UserRepository(GoodReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<IEnumerable<User>> GetAllAsync(int skip = 0, int take = 50)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<User?> GetWithRatingsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(User entity)
    {
        throw new NotImplementedException();
    }

    public void Update(User entity)
    {
        throw new NotImplementedException();
    }

    public void Delete(User entity)
    {
        throw new NotImplementedException();
    }
}