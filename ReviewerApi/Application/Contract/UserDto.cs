using Domain.Enum;

namespace Application.Contract;

public record UserDto
{
    public required Guid Id { get; init; }
    public required string Email { get; init; }
    public required Role Role { get; init; }
}
