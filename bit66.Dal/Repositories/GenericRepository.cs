using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal.Repositories;

public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: EntityBase
{
    private readonly SoccerDbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public GenericRepository(SoccerDbContext context)
    {
        _context = context;
        _dbSet = context.Set<TEntity>();
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> FindAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public virtual void Add(TEntity entity)
    {
        _dbSet.Add(entity);
    }

    public virtual void Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entityToDelete = await FindAsync(id);
        _dbSet.Remove(entityToDelete!);
    }
}