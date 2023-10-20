namespace Domain.Entities;

public class Course
{
    public long Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public double AvarageGrade { get; set; }
    
    public List<Comment> Comments { get; set; } = new();
}
