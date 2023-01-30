using bit66.Domain.Entities;

namespace bit66.Domain.Interfaces.Repository;

public interface IGenericRepository<T> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<T?> FindAsync(int id);
    
    Task AddAsync(T entity);

    Task UpdateAsync(int id, T entity);

    Task DeleteAsync(int id);
}