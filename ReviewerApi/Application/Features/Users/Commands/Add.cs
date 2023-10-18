using Application.Contract;
using Application.Shared;
using Domain.Entities;
using Domain.Enum;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Commands;

public record CreateUserCommand : IRequest<UserDto>
{
    public required string Username { get; init; }

    public required string Password { get; init; }

    public required Role Role { get; init; }
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
            Username = request.Username,
            HashPassword = await _userRepository.HashPasswordAsync(request.Password),
            Role = request.Role,
        };

        _userRepository.Add(user);
        await _unitOfWork.CommitAsync();

        var response = new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Role = user.Role,
        };

        return response;
    }
}
