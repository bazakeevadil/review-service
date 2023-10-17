using Domain.Entities;
using Infrastructure.Shared;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetById(Guid id);
    Task<User?> GetByUsername(string username);
    Task<string> HashPasswordAsync(string password);
    Task<User?> CheckUserCredentials(string username, string password);
}
