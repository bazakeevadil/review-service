namespace Application.Features.Courses.Request;

public record GetCourseByIdQuery : IRequest<CourseDto?>
{
    public long Id { get; init; }
}

internal class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
{
    private readonly ICourseRepository _courseRepository;

    public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseById(request.Id);
        if (course is not null)
        {

            var response = course.Adapt<CourseDto>();
            return response;
        }
        return default;
    }
}

