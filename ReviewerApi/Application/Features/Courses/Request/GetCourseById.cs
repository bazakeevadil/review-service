
using Application.Contract;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Request;

public record GetCourseByIdQuery : IRequest<CourseDto?>
{
    public long Id { get; init; }
}

internal class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, CourseDto?>
{
    private readonly ICourseRepo _courseRepository;

    public GetCourseByIdHandler(ICourseRepo courseRepository)
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

