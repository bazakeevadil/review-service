namespace Application.Features.Users.Requests;

public record GetUserByEmailQuery : IRequest<UserDto?>
{
    public required string Email { get; init; }
}

internal class GetUserByEmailQueryHandler
    : IRequestHandler<GetUserByEmailQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByEmailQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> Handle(
        GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email);

        var response = user.Adapt<UserDto?>();

        return response;
    }
}
