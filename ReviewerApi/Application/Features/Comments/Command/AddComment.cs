using Application.Shared;

namespace Application.Features.Comments.Command;

public record CreateCommentCommand : IRequest<CommentDto>
{
    public required string? Content { get; init; }
    public required short Grade { get; init; }
}

internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
{
    private readonly ICommentRepository _commentRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommentCommandHandler(ICommentRepository commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepo = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var comment = new Comment
        {
            Content = request.Content,
            GradeForCourse = request.Grade,
        };

        _commentRepo.Add(comment);
        await _unitOfWork.CommitAsync();

        var response = new CommentDto
        {
            Id = comment.Id,
            Content = comment.Content,
            Grade = request.Grade,
        };

        return response;
    }
}