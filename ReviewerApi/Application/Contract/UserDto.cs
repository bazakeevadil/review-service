using Domain.Enum;

namespace Application.Contract;

public record UserDto
{
    public required long Id { get; init; }
    public required string Email { get; init; }
    public required Role Role { get; init; }
    public List<Comment> Comments { get; init; } = new();
}
