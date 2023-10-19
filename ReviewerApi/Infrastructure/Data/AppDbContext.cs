using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<User> Users => Set<User>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Comment> Comments => Set<Comment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var userRepository = this.GetService<IUserRepository>();
        var passwordHash = userRepository.HashPasswordAsync("admin").GetAwaiter().GetResult();
        modelBuilder.Entity<User>()
            .HasData(
                new User
                {
                    Id = 1,
                    Email = "admin@gmail.com",
                    HashPassword = passwordHash,
                    Role = Domain.Enum.Role.Admin,
                });
    }


}
