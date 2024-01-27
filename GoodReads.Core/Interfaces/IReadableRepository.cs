using GoodReads.Core.Models;
using GoodReads.Core.Entities;

namespace GoodReads.Core.Interfaces;

public interface IReadableRepository<TEntity> where TEntity : BaseEntity
{
    Task<PaginationResult<TEntity>> GetAllAsync(int page = 1, int pageSize = 10);
    Task<TEntity?> GetByIdAsync(int id);
}