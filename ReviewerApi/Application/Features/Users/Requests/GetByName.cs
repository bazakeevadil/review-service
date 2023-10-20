namespace Application.Features.Users.Requests;

public record GetUserByUsernameQuery : IRequest<UserDto?>
{
    public required string Email { get; init; }
}

internal class GetUserByUsernameQueryHandler
    : IRequestHandler<GetUserByUsernameQuery, UserDto?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByUsernameQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserDto?> Handle(
        GetUserByUsernameQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(request.Email);

        var response = user.Adapt<UserDto?>();

        return response;
    }
}
