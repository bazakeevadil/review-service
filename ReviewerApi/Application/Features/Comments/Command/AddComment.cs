using Application.Contract;
using Application.Shared;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Comments.Command;

public record CreateCommentCommand : IRequest<CommentDto>
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}

internal class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, CommentDto>
{
    private readonly ICommentRepo _commentRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCommentCommandHandler(ICommentRepo commentRepository, IUnitOfWork unitOfWork)
    {
        _commentRepo = commentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CommentDto> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
    {
        var course = new Comment
        {

        };

        _commentRepo.Add(course);
        await _unitOfWork.CommitAsync();

        var response = new CommentDto
        {
            Id = course.Id,
        };

        return response;
    }
}