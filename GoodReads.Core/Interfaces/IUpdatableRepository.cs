using GoodReads.Core.Entities;

namespace GoodReads.Core.Interfaces;

public interface IUpdatableRepository<TEntity> where TEntity : BaseEntity
{
    void Update(TEntity entity);
}