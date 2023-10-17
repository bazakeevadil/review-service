using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Comment
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public User? User { get; set; }
    public string? CourseId { get; set; }
    public Course? Course { get; set; }
    public string? Content { get; set; }
    public short Grade { get; set; }
}
