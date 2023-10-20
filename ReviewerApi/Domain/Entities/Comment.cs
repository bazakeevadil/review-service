using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Comment
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long CourseId { get; set; }
    public string? Content { get; set; }

    [Range(1, 5, ErrorMessage = "Допустимая оценка от 1 до 5")]
    public short GradeForCourse { get; set; }

    public User? User { get; set; }
    public Course? Course { get; set; }
}
