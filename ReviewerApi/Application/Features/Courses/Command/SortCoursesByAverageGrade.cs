namespace Application.Features.Courses.Command;


public record SortCoursesByAGQuery : IRequest<float> { }

internal class SCBAGQueryHandler : IRequestHandler<SortCoursesByAGQuery, float>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly ICourseRepository _courseRepository;

    public SCBAGQueryHandler(IReviewRepository reviewRepository, ICourseRepository courseRepository)
    {
        _reviewRepository = reviewRepository;
        _courseRepository = courseRepository;
    }

    public async Task<float> Handle(
        SortCoursesByAGQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetAllAsync();

        int current = 0;
        float value = 0;

        foreach (var item in reviews)
        {
            value += item.Grade;
            current++;
        }
        float result = value / current;

        var response =  result;

        return response;
    }
}
