using Application.Contract;
using Application.Shared;
using Domain.Enum;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Commands;

public record UpdateUserCommand : IRequest<UserDto?>
{
    public required string Email { get; init; }

    public required string Password { get; init; }

    public required Role Role { get; init; }
}

internal class UpdateUserHandler : IRequestHandler<UpdateUserCommand, UserDto?>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateUserHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto?> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(command.Email);
        if (user is not null)
        {
            user.Email ??= command.Email;
            user.HashPassword ??= command.Password;
            user.Role = command.Role;

            _userRepository.Update(user);
            await _unitOfWork.CommitAsync();

            var response = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
            };
            return response;
        }
        return default;
    }
}
