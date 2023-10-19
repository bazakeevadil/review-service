﻿namespace Application.Contract;

public class CourseDto
{
    public required long Id { get; init; }
    public required string? Name { get; init; }
    public required string? Description { get; init; }
}
