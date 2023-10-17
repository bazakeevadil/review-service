using Application.Shared;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Commands;

public record DeleteUsersByIdCommand : IRequest
{
    public required Guid Id { get; init; }
}

internal class DeleteUsersByIdCommandHandler : IRequestHandler<DeleteUsersByIdCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUsersByIdCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteUsersByIdCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(command.Id);
        if (user == null) return;

        await _userRepository.DeleteByIdAsync(user.Id);
        await _unitOfWork.CommitAsync();
    }
}
