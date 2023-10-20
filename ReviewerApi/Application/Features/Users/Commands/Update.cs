using Application.Shared;
using FluentResults;

namespace Application.Features.Users.Commands;

public record PatchUserCommand : IRequest<Result>
{
    public required string Email { get; init; }

    public required PatchUserProps Props { get; init; }
}

public record PatchUserProps
{
    public string? Email { get; init; }
    public string? Password { get; init; }

}

internal class PatchUserCommandHandler
    : IRequestHandler<PatchUserCommand, Result>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _uow;

    public PatchUserCommandHandler(IUserRepository userRepository, IUnitOfWork uow)
    {
        _userRepository = userRepository;
        _uow = uow;
    }

    public async Task<Result> Handle(
        PatchUserCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email);

        if (user == null)
            return Result.Fail($"User with email {request.Email} was not found.");

        if (!string.IsNullOrWhiteSpace(request.Props.Email))
            user.Email = request.Props.Email!;

        if (!string.IsNullOrWhiteSpace(request.Props.Password))
            user.HashPassword = request.Props.Password!;

        _userRepository.Update(user);
        await _uow.CommitAsync();

        return Result.Ok();
    }
}
