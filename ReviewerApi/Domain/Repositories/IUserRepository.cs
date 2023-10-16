using Domain.Entities;
using Infrastructure.Shared;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByUsername(string username);
    Task<string> HashPasswordAsync(string password);
}
