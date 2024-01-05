using GoodReads.Domain.Entities;

namespace GoodReads.Domain.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> GetWithRatingsByIdAsync(int id);
}