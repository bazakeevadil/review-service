using Application.Shared;

namespace Application.Features.Comments.Command;

public record UpdateCommentCommand : IRequest<CommentDto?>
{
    public required long Id { get; init; }
    public required string? Content { get; init; }
    public required short Grade { get; init; }
}

internal class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, CommentDto?>
{
    private readonly ICommentRepo _commentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCommentCommandHandler(ICommentRepo commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepository = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CommentDto?> Handle(UpdateCommentCommand command, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetCommentById(command.Id);
        if (comment is not null)
        {
            comment.Content = command.Content;
            comment.Grade = command.Grade;

            _commentRepository.Update(comment);
            await _unitOfWork.CommitAsync();

            var response = new CommentDto
            {
                Id = comment.Id,
                Content = command.Content,
                Grade = command.Grade,              
            };
            return response;
        }
        return default;
    }
}