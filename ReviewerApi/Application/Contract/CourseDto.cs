using Domain.Entities;

namespace Application.Contract;

public class CourseDto
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public List<Comment> Comments { get; set; } = new();
}
