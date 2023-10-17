﻿using Domain.Entities;
using Domain.Enum;

namespace Application.Contract;

public record UserDto
{
    public required Guid Id { get; init; }
    public required string Username { get; init; }
    public required Role Role { get; init; }
    public List<Comment> Comments { get; set; } = new();
}
