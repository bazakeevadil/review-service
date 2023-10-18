
using MediatR;

namespace Application.Features.Courses.Request;


{
    public long Id { get; init; }
    public string? Name { get; init; }
    public string? Description { get; init; }
}

public record GetCourseByIdQuery : IRequest<GetCourseByIdCommand?>
{
    public required long Id { get; init; }
}

{
    private readonly ICourseRepo _courseRepository;

    public GetCourseByIdHandler(ICourseRepo courseRepository)
    {
        _courseRepository = courseRepository;
    }

    {
        var user = await _courseRepository.GetCourseById(command.Id);
        if (user is not null)
        {

            var response = new GetCourseByIdCommand
            {
                Id = command.Id,
            };
            return response;
        }
        return default;
    }
}

