using Application.Shared;

namespace Application.Features.Courses.Command;

public record DeleteCourseByNameCommand : IRequest
{
    public required string Name { get; init; }
}

internal class DeleteCourseCommandHandler
    : IRequestHandler<DeleteCourseByNameCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _uow;

    public DeleteCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork uow)
    {
        _courseRepository = courseRepository;
        _uow = uow;
    }

    public async Task Handle(DeleteCourseByNameCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseByName(request.Name);
        if (course is not null)
        {
            _courseRepository.Delete(course);
            await _uow.CommitAsync();
        }
    }
}
