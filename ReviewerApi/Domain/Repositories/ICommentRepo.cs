using Domain.Entities;
using Infrastructure.Shared;

namespace Domain.Repositories;

public interface ICommentRepo : IRepository<Comment>
{
    Task<Comment?> GetCommentById(long id);
    Task DeleteCommentByIdAsync(long id);
}
