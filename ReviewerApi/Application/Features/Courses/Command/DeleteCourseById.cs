using Application.Contract;
using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Command;


public record DeleteCourseByIdCommand : IRequest
{
    public required long Id { get; init; }
}

internal class DeleteCourseByIdCommandHandler : IRequestHandler<DeleteCourseByIdCommand>
{
    private readonly ICourseRepo _courseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCourseByIdCommandHandler(ICourseRepo courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepository = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCourseByIdCommand command, CancellationToken cancellationToken)
    {
        var course = await _courseRepository.GetCourseById(command.Id);
        if (course == null) return;

        await _courseRepository.DeleteByIdAsync(course.Id);
        await _unitOfWork.CommitAsync();
    }
}
