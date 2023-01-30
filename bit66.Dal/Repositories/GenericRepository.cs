using bit66.Domain.Entities;
using bit66.Domain.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace bit66.Dal.Repositories;

public class GenericRepository<TEntity>: IGenericRepository<TEntity> where TEntity: EntityBase
{
    internal SoccerDbContext context;
    internal DbSet<TEntity> dbSet;

    public GenericRepository(SoccerDbContext context)
    {
        this.context = context;
        dbSet = context.Set<TEntity>();
    }
    
    public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public virtual async Task<TEntity?> FindAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await dbSet.AddAsync(entity);
    }

    public virtual async Task UpdateAsync(int id, TEntity entity)
    {
        var entityToUpdate = await dbSet.FindAsync(id);
        dbSet.Update(entityToUpdate!).CurrentValues.SetValues(entity);
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entityToDelete = await dbSet.FindAsync(id);
        dbSet.Remove(entityToDelete!);
    }
}