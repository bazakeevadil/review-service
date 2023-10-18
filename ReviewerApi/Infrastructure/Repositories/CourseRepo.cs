﻿using Domain.Entities;
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
        throw new NotImplementedException();
    }

    public Task<List<Course>> GetAllAsync()
    {
        return _context.Courses.AsNoTracking().ToListAsync();
    }

    public Task<Course?> GetCourseById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Course?> GetCourseByName(string name)
    {
        throw new NotImplementedException();
    }

    public void Update(Course entity)
    {
        throw new NotImplementedException();
    }
}