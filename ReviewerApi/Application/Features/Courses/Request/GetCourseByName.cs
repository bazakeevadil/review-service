using Application.Contract;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Courses.Request;


public record GetCourseByNameQuery : IRequest<CourseDto?>
{
    public required string Name { get; init; }
}

internal class GetCourseByNameQueryHandler
    : IRequestHandler<GetCourseByNameQuery, CourseDto?>
{
    private readonly ICourseRepo _courseRepository;

    public GetCourseByNameQueryHandler(ICourseRepo courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> Handle(
        GetCourseByNameQuery request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseByName(request.Name);

        var response = course.Adapt<CourseDto?>();

        return response;
    }
}
