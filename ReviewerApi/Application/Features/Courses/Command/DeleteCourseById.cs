using Application.Shared;

namespace Application.Features.Courses.Command;

public record DeleteCourseByIdCommand : IRequest
{
    public required long Id { get; init; }
}

internal class DeleteCourseByIdCommandHandler : IRequestHandler<DeleteCourseByIdCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCourseByIdCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCourseByIdCommand command, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseById(command.Id);
        if (course is not null)
        {
            await _courseRepository.DeleteByIdAsync(course.Id);
            await _unitOfWork.CommitAsync();
        }
    }
}
