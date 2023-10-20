using Application.Shared;

namespace Application.Features.Users.Commands;

public record DeleteUserByIdCommand : IRequest
{
    public required long Id { get; init; }
}

internal class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteUserByIdCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(command.Id);
        if (user == null) return;

        await _userRepository.DeleteByIdAsync(user.Id);
        await _unitOfWork.CommitAsync();
    }
}
