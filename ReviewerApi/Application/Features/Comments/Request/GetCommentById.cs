using Application.Contract;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Comments.Request;

public record GetCommentByIdQuery : IRequest<CommentDto?>
{
    public long Id { get; init; }
}

internal class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ICommentRepo _commentRepository;

    public GetCommentByIdHandler(ICommentRepo commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<CommentDto?> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
    {
        var course = await _commentRepository.GetCommentById(request.Id);
        if (course is not null)
        {

            var response = new CommentDto
            {
                Id = request.Id,
                Content = course.Content,
                Grade = course.Grade,
            };
            return response;
        }
        return default;
    }
}
