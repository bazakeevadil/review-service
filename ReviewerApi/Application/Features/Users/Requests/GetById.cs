using Domain.Enum;
using Domain.Repositories;
using MediatR;

namespace Application.Features.Users.Requests;

public record GetUserResponseById
{
    public long Id { get; set; }
    public required string Email { get; set; }
    public required Role Role { get; init; }
}

public record GetUserByIdQuery : IRequest<GetUserResponseById?>
{
    public required long Id { get; init; }
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
                Email = user.Email,
                Role = user.Role,
            };
            return response;
        }
        return default;
    }
}
