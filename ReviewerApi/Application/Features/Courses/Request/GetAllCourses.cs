using Application.Contract;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Courses.Request;
public record GetAllCoursesQuery : IRequest<List<CourseDto>> { }

internal class GetAllCoursesQueryHandler
    : IRequestHandler<GetAllCoursesQuery, List<CourseDto>>
{
    private readonly ICourseRepo _courseRepository;

    public GetAllCoursesQueryHandler(ICourseRepo userRepository)
    {
        _courseRepository = userRepository;
    }

    public async Task<List<CourseDto>> Handle(
        GetAllCoursesQuery request, CancellationToken cancellationToken)
    {
        var users = await _courseRepository.GetAllAsync();

        var response = users.Adapt<List<CourseDto>>();

        return response;
    }
}

