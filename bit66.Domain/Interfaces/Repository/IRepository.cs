using bit66.Domain.Entities;

namespace bit66.Domain.Interfaces.Repository;

public interface IRepository<T> where T: EntityBase
{
    Task<T> FindAsync(int id);
    
    Task AddAsync(T entity);

    Task EditAsync(int id);

    Task DeleteAsync(int id);

    Task SaveAsync();
}