namespace Application.Features.Courses.Request;
public record GetAllCoursesQuery : IRequest<List<CourseDto>> { }

internal class GetAllCoursesQueryHandler
    : IRequestHandler<GetAllCoursesQuery, List<CourseDto>>
{
    private readonly ICourseRepository _courseRepository;

    public GetAllCoursesQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<List<CourseDto>> Handle(
        GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetAllAsync();

        var response = courses.Adapt<List<CourseDto>>();

        return response;
    }
}

