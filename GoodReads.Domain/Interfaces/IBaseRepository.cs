using GoodReads.Domain.Entities;

namespace GoodReads.Domain.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<IEnumerable<TEntity>> GetAllAsync(int skip = 0, int take = 50);
    Task<TEntity?> GetByIdAsync(int id);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}