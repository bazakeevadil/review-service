namespace Domain.Entities;

public class Comment
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long CourseId { get; set; }
    public string? Content { get; set; }
    public short GradeForCourse { get; set; }

    public User? User { get; set; }
    public Course? Course { get; set; }
}
