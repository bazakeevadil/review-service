namespace Infrastructure.Shared;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    Task CreateAsync(TEntity entity);
    void Update(TEntity entity);
    Task<bool> DeleteAsync(string names);
    Task<bool> DeleteAsync(Guid Id);
}
