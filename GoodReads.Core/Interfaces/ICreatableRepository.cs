using GoodReads.Core.Entities;

namespace GoodReads.Core.Interfaces;

public interface ICreatableRepository<TEntity> where TEntity : BaseEntity
{
    void Create(TEntity entity);
}