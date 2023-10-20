using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _context;

    public ReviewRepository(AppDbContext context)
    {
        _context = context;
    }


    public void Add(Review entity)
    {
        _context.Reviews.Add(entity);
    }

    public void Delete(Review entity)
    {
        _context.Reviews.Remove(entity);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await _context.Reviews.FindAsync(id);

        if (entity is not null)
            _context.Reviews.Remove(entity);
    }

    public Task<List<Review>> GetAllAsync()
    {
        return _context.Reviews.AsNoTracking().ToListAsync();
    }

    public async Task<Review?> GetById(long id)
    {
        var entity = await _context.Reviews.FindAsync(id);

        if (entity != null)
            _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public void Update(Review entity)
    {
        _context.Reviews.Update(entity);
    }
}
