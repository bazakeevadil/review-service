using Domain.Entities;
using Infrastructure.Shared;

namespace Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetById(Guid id);
    Task<User?> GetByEmail(string email);
    Task<string> HashPasswordAsync(string password);
    Task<User?> CheckUserCredentials(string email, string password);
    Task DeleteByIdAsync(Guid Id);
}
