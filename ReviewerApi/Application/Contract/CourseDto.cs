﻿using Domain.Entities;

namespace Application.Contract;

public class CourseDto
{
    public long Id { get; init; }
    public required string? Name { get; init; }
    public required string? Description { get; init; }
}
