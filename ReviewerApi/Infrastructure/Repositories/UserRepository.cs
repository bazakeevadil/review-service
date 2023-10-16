using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace Infrastructure.Repositories;

internal class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(User entity)
    {
        _context.Users.Add(entity);
    }

    public Task<List<User>> GetAllAsync()
    {
        return _context.Users.AsNoTracking().ToListAsync();
    }

    public async Task<User?> GetUserById(Guid id)
    {
        var entity = await _context.Users.FindAsync(id);

        if (entity != null)
            _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public Task<User?> GetUserByUsername(string username)
    {
        return _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<string> HashPasswordAsync(string password)
    {
        var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        return await Task.FromResult(hash).ConfigureAwait(false);
    }

    public void Update(User entity)
    {
        _context.Users.Update(entity);
    }

    public void DeleteByName(User entity)
    {
        _context.Users.Remove(entity);
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var entity = await _context.Users.FindAsync(id);

        if (entity != null)
            _context.Users.Remove(entity);
    }
}
