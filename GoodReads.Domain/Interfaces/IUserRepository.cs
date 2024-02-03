using GoodReads.Core.Interfaces;
using GoodReads.Domain.Users;

namespace GoodReads.Domain.Interfaces;

public interface IUserRepository : IReadableRepository<User>, ICreatableRepository<User>, IUpdatableRepository<User>, IDeletableRepository<User>
{
    Task<User?> GetWithRatingsByIdAsync(int id);
    Task<User?> GetWithRatingsInPeriodByIdAsync(int id, DateTime startDate, DateTime finishDate);
}