using Domain.Entities;
using Infrastructure.Shared;

namespace Domain.Repositories;

public interface IReviewRepository : IRepository<Review>
{
    Task<Review?> GetById(long id);
    Task DeleteByIdAsync(long id);
}
