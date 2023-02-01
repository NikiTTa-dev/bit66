using bit66.Domain.Entities;

namespace bit66.Domain.Interfaces.Repository;

public interface IGenericRepository<T> where T : EntityBase
{
    Task<IEnumerable<T>> GetAllAsync();
    
    Task<T?> FindAsync(int id);
    
    void Add(T entity);

    void Update(T entity);

    Task DeleteAsync(int id);
}