using Application.Shared;

namespace Application.Features.Comments.Command;

public record DeleteCommentByIdCommand : IRequest
{
    public required long Id { get; init; }
}

internal class DeleteCommentByIdCommandHandler : IRequestHandler<DeleteCommentByIdCommand>
{
    private readonly ICommentRepository _commentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCommentByIdCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
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
