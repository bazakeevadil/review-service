using System.Collections.Generic;

namespace Application.Features.Courses.Command;


public record SortCoursesByAGQuery : IRequest<float> { }

internal class SCBAGQueryHandler : IRequestHandler<SortCoursesByAGQuery, float>
{
    private readonly ICommentRepository _commentRepository;
    private readonly ICourseRepository _courseRepository;

    public SCBAGQueryHandler(ICommentRepository commentRepository, ICourseRepository courseRepository)
    {
        _commentRepository = commentRepository;
        _courseRepository = courseRepository;
    }

    public async Task<float> Handle(
        SortCoursesByAGQuery request, CancellationToken cancellationToken)
    {
        var comments = await _commentRepository.GetAllAsync();

        int current = 0;
        float value = 0;

        foreach (var item in comments)
        {
            value += item.GradeForCourse;
            current++;
        }
        float result = value / current;

        var response =  result;

        return response;
    }
}
