using Domain.Entities;
using Microsoft.VisualBasic;

namespace Infrastructure.Shared;

public interface IRepository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    void Add(TEntity entity);
    void Update(TEntity entity);
    void DeleteByName(TEntity entity);
}
