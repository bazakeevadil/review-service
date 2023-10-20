namespace Application.Features.Comments.Request;

public record GetAllCommentsQuery : IRequest<List<CommentDto>> { }

internal class GetAllCommentQueryHandler
    : IRequestHandler<GetAllCommentsQuery, List<CommentDto>>
{
    private readonly ICommentRepository _commentRepository;

    public GetAllCommentQueryHandler(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<List<CommentDto>> Handle(
        GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
        var comment = await _commentRepository.GetAllAsync();
        
        var response = comment.Adapt<List<CommentDto>>();

        return response;
    }
}
