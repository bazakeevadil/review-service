using Domain.Enum;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Requests;

public record GetUserResponseById
{
    public Guid Id { get; set; }
    public required string Username { get; set; }
    public required Role Role { get; init; }
}

public record GetUserByIdQuery : IRequest<GetUserResponseById?>
{
    public required Guid Id { get; init; }
}

internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserResponseById?>
{
    private readonly IUserRepository _userRepository;

    public GetUserByIdQueryHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserResponseById?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(request.Id);
        if (user is not null)
        {
            var response = new GetUserResponseById
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role,
            };
            return response;
        }
        return default;
    }
}
