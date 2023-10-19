using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Entities;

public class User
{
    public long Id { get; set; }

    [DisplayName("Имя пользователя")]
    [Required(ErrorMessage = "{0} является обязательным полем")]
    [StringLength(20)]
    public required string Email { get; set; }

    [DisplayName("Захешированный пароль")]
    [Required(ErrorMessage = "{0} является обязательным полем")]
    [StringLength(200)]
    public required string HashPassword { get; set; }
    public Role Role { get; set; }
    public List<Comment> Comments { get; set; } = new();
}
