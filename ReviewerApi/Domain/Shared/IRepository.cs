namespace Infrastructure.Shared;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
