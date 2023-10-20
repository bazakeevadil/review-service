using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly AppDbContext _context;

    public CourseRepository(AppDbContext context)
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

    public void Delete(Course entity)
    {
        _context.Courses.Remove(entity);
    }

    public Task<List<Course>> GetAllAsync()
    {
        return _context.Courses.Include(c => c.Reviews).AsNoTracking().ToListAsync();
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

    public async Task<List<(double, Course)>> SortCoursesByAverageGrade()
    {
        var courses = await _context.Courses.AsNoTracking().Include(c => c.Reviews).ToListAsync();
        var sortedCourses = courses.Select(c => (c.Reviews.Any() ? c.Reviews.Average(com => com.Grade) : 0, c)).OrderBy(t => t.Item1).ToList();
        return sortedCourses;
    }
}
