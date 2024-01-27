using Microsoft.EntityFrameworkCore.Storage;

using GoodReads.Core.Interfaces;
using GoodReads.Infrastructure.Persistences.Data;

namespace GoodReads.Infrastructure.Persistences.Repositories;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly GoodReadsDbContext _dbContext;
    private IDbContextTransaction? _transaction;

    public UnitOfWork(GoodReadsDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await _transaction.CommitAsync();
        }
        catch
        {
            await _transaction.RollbackAsync();
            throw;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (disposing)
            _dbContext.Dispose();
    }
}