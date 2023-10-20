using Domain.Enum;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class User
{
    public long Id { get; set; }

    [StringLength(150)]
    public required string Email { get; set; }

    [StringLength(200)]
    public required string HashPassword { get; set; }
    public Role Role { get; set; }

    public List<Review> Reviews { get; set; } = new();
}
