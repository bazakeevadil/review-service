using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Command;

public record DeleteCourseCommand : IRequest
{
    public required string Name { get; init; }
}

internal class DeleteCourseCommandHandler
    : IRequestHandler<DeleteCourseCommand>
{
    private readonly ICourseRepo _courseRepository;
    private readonly IUnitOfWork _uow;

    public DeleteCourseCommandHandler(ICourseRepo courseRepository, IUnitOfWork uow)
    {
        _courseRepository = courseRepository;
        _uow = uow;
    }

    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseByName(request.Name);
        if (course == null) return;

        _courseRepository.Delete(course);
        await _uow.CommitAsync();
    }
}
