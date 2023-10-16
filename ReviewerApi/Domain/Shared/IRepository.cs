using Domain.Entities;

namespace Infrastructure.Shared;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void DeleteByName(User entity);
    Task DeleteByIdAsync(Guid Id);
}
