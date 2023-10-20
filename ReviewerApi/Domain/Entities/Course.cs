using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Course
{
    public long Id { get; set; }

    [StringLength(100)]
    public required string Name { get; set; }

    [StringLength(2000)]
    public string? Description { get; set; }

    public List<Review> Reviews { get; set; } = new();
}
