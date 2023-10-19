using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Comments.Command;

public record DeleteCommentByIdCommand : IRequest
{
    public required long Id { get; init; }
}

internal class DeleteCommentByIdCommandHandler : IRequestHandler<DeleteCommentByIdCommand>
{
    private readonly ICommentRepo _commentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommentByIdCommandHandler(ICommentRepo commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteCommentByIdCommand command, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentById(command.Id);
        if (comment is not null)
        {
            await _commentRepository.DeleteCommentByIdAsync(comment.Id);
            await _unitOfWork.CommitAsync();
        }
    }
}
