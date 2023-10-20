using Application.Shared;

namespace Application.Features.Users.Commands;

public record DeleteUserCommand : IRequest
{
    public required string Email { get; init; }
}

internal class DeleteUserCommandHandler
    : IRequestHandler<DeleteUserCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;

    public DeleteUserCommandHandler(IUserRepository userRepository, IUnitOfWork uow)
    {
        _userRepository = userRepository;
        _uow = uow;
    }

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email);
        if (user == null) return;

        _userRepository.Delete(user);
        await _uow.CommitAsync();
    }
}
