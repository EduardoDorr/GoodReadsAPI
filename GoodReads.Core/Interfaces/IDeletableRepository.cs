using GoodReads.Core.Entities;

namespace GoodReads.Core.Interfaces;

public interface IDeletableRepository<TEntity> where TEntity : BaseEntity
{
    void Delete(TEntity entity);
}