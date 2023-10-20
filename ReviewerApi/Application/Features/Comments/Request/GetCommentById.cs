namespace Application.Features.Comments.Request;

public record GetCommentByIdQuery : IRequest<CommentDto?>
{
    public long Id { get; init; }
}

internal class GetCommentByIdQueryHandler : IRequestHandler<GetCommentByIdQuery, CommentDto?>
{
    private readonly ICommentRepository _commentRepository;

    public GetCommentByIdQueryHandler(ICommentRepository commentRepository)
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
                Grade = course.GradeForCourse,
            };
            return response;
        }
        return default;
    }
}
