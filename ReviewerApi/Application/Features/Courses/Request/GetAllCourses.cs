﻿namespace Application.Features.Courses.Request;
public record GetAllCoursesQuery : IRequest<List<CourseDto>> { }

internal class GetAllCoursesQueryHandler
    : IRequestHandler<GetAllCoursesQuery, List<CourseDto>>
{
    private readonly ICourseRepository _courseRepository;

    public GetAllCoursesQueryHandler(ICourseRepository commentRepository)
    {
        _courseRepository = commentRepository;
    }

    public async Task<List<CourseDto>> Handle(
        GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var comment = await _courseRepository.GetAllAsync();

        var response = comment.Adapt<List<CourseDto>>();

        return response;
    }
}

