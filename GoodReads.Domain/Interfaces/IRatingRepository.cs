using GoodReads.Core.Interfaces;
using GoodReads.Domain.Ratings;

namespace GoodReads.Domain.Interfaces;

public interface IRatingRepository : IReadableRepository<Rating>, ICreatableRepository<Rating>, IUpdatableRepository<Rating>, IDeletableRepository<Rating>
{
}