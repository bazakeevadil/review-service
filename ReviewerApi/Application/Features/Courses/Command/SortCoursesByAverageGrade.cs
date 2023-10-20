namespace Application.Features.Courses.Command;


public record SortCoursesByAGQuery : IRequest<List<SortedCourseDto>> { }

internal class SCBAGQueryHandler : IRequestHandler<SortCoursesByAGQuery, List<SortedCourseDto>>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly ICourseRepository _courseRepository;

    public SCBAGQueryHandler(IReviewRepository reviewRepository, ICourseRepository courseRepository)
    {
        _reviewRepository = reviewRepository;
        _courseRepository = courseRepository;
    }

    public async Task<List<SortedCourseDto>> Handle(
        SortCoursesByAGQuery request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.SortCoursesByAverageGrade();

        return courses.Select(c => new SortedCourseDto { AverageGrade = c.Item1, Course = c.Item2.Adapt<CourseDto>()}).ToList();
    }
}
