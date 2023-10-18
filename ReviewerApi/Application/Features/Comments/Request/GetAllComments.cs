using Application.Contract;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Features.Comments.Request;

public record GetAllCommentsQuery : IRequest<List<CommentDto>> { }

internal class GetAllCommentQueryHandler
    : IRequestHandler<GetAllCommentsQuery, List<CommentDto>>
{
    private readonly ICommentRepo _courseRepository;

    public GetAllCommentQueryHandler(ICommentRepo commentRepository)
    {
        _courseRepository = commentRepository;
    }

    public async Task<List<CommentDto>> Handle(
        GetAllCommentsQuery request, CancellationToken cancellationToken)
    {
        var users = await _courseRepository.GetAllAsync();

        var response = users.Adapt<List<CommentDto>>();

        return response;
    }
}
