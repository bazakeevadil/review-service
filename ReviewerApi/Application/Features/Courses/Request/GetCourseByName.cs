namespace Application.Features.Courses.Request;

public record GetCourseByNameQuery : IRequest<CourseDto?>
{
    public required string Name { get; init; }
}

internal class GetCourseByNameQueryHandler : IRequestHandler<GetCourseByNameQuery, CourseDto?>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseByNameQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> Handle(GetCourseByNameQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseByName(request.Name);
        if (course is not null)
        {

            var response = new CourseDto
            {
                Id = course.Id,
                Name = request.Name,
                Description = course.Description,
            };
            return response;
        }
        return default;
    }
}


