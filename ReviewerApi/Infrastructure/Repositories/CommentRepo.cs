using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CommentRepo : ICommentRepo
{
    private readonly AppDbContext _context;

    public CommentRepo(AppDbContext context)
    {
        _context = context;
    }


    public void Add(Comment entity)
    {
        _context.Comments.Add(entity);
    }

    public void Delete(Comment entity)
    {
        _context.Comments.Remove(entity);
    }

    public async Task DeleteCommentByIdAsync(long id)
    {
        var entity = await _context.Comments.FindAsync(id);

        if (entity is not null)
            _context.Comments.Remove(entity);
    }

    public Task<List<Comment>> GetAllAsync()
    {
        return _context.Comments.AsNoTracking().ToListAsync();
    }

    public async Task<Comment?> GetCommentById(long id)
    {
        var entity = await _context.Comments.FindAsync(id);

        if (entity != null)
            _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public void Update(Comment entity)
    {
        _context.Comments.Update(entity);
    }
}
