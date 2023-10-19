using Application.Contract;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Comments.Request;

public record GetAllCommentsQuery : IRequest<List<CommentDto>> { }

internal class GetAllCommentQueryHandler
    : IRequestHandler<GetAllCommentsQuery, List<CommentDto>>
{
    private readonly ICommentRepo _commentRepository;

    public GetAllCommentQueryHandler(ICommentRepo commentRepository)
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
