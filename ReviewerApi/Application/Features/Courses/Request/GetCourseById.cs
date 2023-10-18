using Application.Contract;
using Application.Features.Users.Requests;
using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Request;


public record GetCourseByIdCommand 
{
    public long Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
}

public record GetCourseByIdQuery : IRequest<GetCourseByIdCommand?>
{
    public required long Id { get; init; }
}

internal class GetCourseByIdHandler : IRequestHandler<GetCourseByIdQuery, GetCourseByIdCommand>
{
    private readonly ICourseRepo _courseRepository;

    public GetCourseByIdHandler(ICourseRepo courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto> Handle(GetCourseByIdCommand command, CancellationToken cancellationToken)
    {
        var user = await _courseRepository.GetCourseById(command.Id);
        if (user is not null)
        {
            var response = new Course
            {
                Id = command.Id,

            };
            return response;
        }
        return default;
    }
}

