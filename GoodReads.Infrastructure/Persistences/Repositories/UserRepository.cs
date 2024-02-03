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

    public async Task<User?> GetWithRatingsByIdAsync(int id)
    {
        return await _dbContext.Users.Include(u => u.Ratings).SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetWithRatingsInPeriodByIdAsync(int id, DateTime startDate, DateTime finishDate)
    {
        return await _dbContext.Users
            .Include(u => u.Ratings.Where(r => r.StartDate >= startDate &&
                                               r.FinishDate <= finishDate))
            .SingleOrDefaultAsync(u => u.Id == id);
    }

    public void Create(User user)
    {
        _dbContext.Users.Add(user);
    }

    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }

    public void Delete(User user)
    {
        _dbContext.Users.Remove(user);
    }
}