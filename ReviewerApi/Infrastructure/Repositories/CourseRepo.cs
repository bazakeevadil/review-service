using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CourseRepo : ICourseRepo
{
    private readonly AppDbContext _context;

    public CourseRepo(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Course entity)
    {
        _context.Courses.Add(entity);
    }

    public async Task DeleteByIdAsync(long id)
    {
        var entity = await _context.Courses.FindAsync(id);

        if (entity is not null)
            _context.Courses.Remove(entity);
    }

    public void DeleteByName(Course entity)
    {
        _context.Courses.Remove(entity);
    }

    public Task<List<Course>> GetAllAsync()
    {
        return _context.Courses.AsNoTracking().ToListAsync();
    }

    public async Task<Course?> GetCourseById(long id)
    {
        var entity = await _context.Courses.FindAsync(id);

        if (entity != null)
            _context.Entry(entity).State = EntityState.Detached;

        return entity;
    }

    public async Task<Course?> GetCourseByName(string name)
    {
        var course = await _context.Courses.FirstOrDefaultAsync(b => b.Name == name);
        return course ?? default;
    }

    public void Update(Course entity)
    {
        _context.Courses.Update(entity);
    }
}
