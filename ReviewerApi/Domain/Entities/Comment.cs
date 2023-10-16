using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Comment
{
    public long UserId { get; set; }
    public User User { get; set; }
    public string CourseId { get; set; }
    public Course Course { get; set; }

    [Required]
    public string Content { get; set; }

    [Range(1, 5)]
    public short Grade { get; set; }
}
