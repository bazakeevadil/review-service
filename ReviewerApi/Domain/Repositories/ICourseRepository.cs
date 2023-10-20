using Domain.Entities;
using Infrastructure.Shared;

namespace Domain.Repositories;

public interface ICourseRepository : IRepository<Course>
{
    Task<Course?> GetCourseById(long id);
    Task<Course?> GetCourseByName(string name);
    Task DeleteByIdAsync(long Id);
    Task<List<(double, Course)>> SortCoursesByAverageGrade();

}
