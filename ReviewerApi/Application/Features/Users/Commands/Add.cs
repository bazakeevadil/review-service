using Application.Shared;
using Domain.Enum;

namespace Application.Features.Users.Commands;

public record CreateUserCommand : IRequest<UserDto>
{
    public required string Email { get; init; }

    public required string Password { get; init; }
}

internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Email = request.Email,
            HashPassword = await _userRepository.HashPasswordAsync(request.Password),
            Role = Role.User
        };

        _userRepository.Add(user);
        await _unitOfWork.CommitAsync();

        var response = new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            Role = user.Role,
        };

        return response;
    }
}
