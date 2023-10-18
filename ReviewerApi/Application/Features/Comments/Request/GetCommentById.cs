using Domain.Repositories;
using MediatR;

namespace Application.Features.Comments.Request;

public record GetCommentByIdCommand
{
    public required long Id { get; init; }
}

public record GetCommentByIdQuery : IRequest<GetCommentByIdCommand?>
{
    public  long Id { get; init; }
    public string? Content { get; init; }
}

internal class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, GetCommentByIdCommand>
{
    private readonly ICommentRepo _commentRepository;

    public GetCommentByIdHandler(ICommentRepo commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<GetCommentByIdCommand> Handle(GetCommentByIdQuery command, CancellationToken cancellationToken)
    {
        var user = await _commentRepository.GetCommentById(command.Id);
        if (user is not null)
        {

            var response = new GetCommentByIdCommand
            {
                Id = command.Id,
            };
            return response;
        }
        return default;
    }
}
