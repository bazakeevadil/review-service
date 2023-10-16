using Domain.Entities;
using Infrastructure.Shared;

namespace Domain.Repositories;

public interface ICourseRepo : IRepository<Course>
{
    Task<Course?> GetCourseById(long id);
    Task<Course?> GetCourseByName(string name);

}
