using Microsoft.EntityFrameworkCore;

using GoodReads.Core.Models;
using GoodReads.Domain.Users;
using GoodReads.Domain.Interfaces;
using GoodReads.Infrastructure.Persistences.Data;
using GoodReads.Infrastructure.Persistences.Extensions;

namespace GoodReads.Infrastructure.Persistences.Repositories;

public class UserRepository : IUserRepository
{
    private readonly GoodReadsDbContext _dbContext;

    public UserRepository(GoodReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<PaginationResult<User>> GetAllAsync(int page = 1, int pageSize = 10)
    {
        IQueryable<User> users = _dbContext.Users;

        return await users.GetPaged(page, pageSize);
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public Task<User?> GetWithRatingsByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public void Create(User entity)
    {
        _dbContext.Users.Add(entity);
    }

    public void Update(User entity)
    {
        _dbContext.Users.Update(entity);
    }

    public void Delete(User entity)
    {
        _dbContext.Users.Remove(entity);
    }
}