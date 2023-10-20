namespace Application.Features.Courses.Request;

public record GetCourseByIdQuery : IRequest<CourseDto?>
{
    public long Id { get; init; }
}

internal class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
{
    private readonly ICourseRepo _courseRepository;

    public GetCourseByIdQueryHandler(ICourseRepo courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseById(request.Id);
        if (course is not null)
        {

            var response = new CourseDto
            {
                Id = request.Id,
                Name = course.Name,
                Description = course.Description,
            };
            return response;
        }
        return default;
    }
}

