
using Application.Contract;
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

    public async Task<GetCourseByIdCommand> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _courseRepository.GetCourseById(request.Id);
        if (user is not null)
        {

            var response = new GetCourseByIdCommand
            {
                Id = request.Id,
            };
            return response;
        }
        return default;
    }
}

