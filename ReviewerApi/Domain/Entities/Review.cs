using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Review
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public required long CourseId { get; set; }

    [StringLength(2000)]
    public string? Content { get; set; }
    public short Grade { get; set; }

    public User? User { get; set; }
    public Course? Course { get; set; }
}
