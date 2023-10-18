using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Укажите email")]
    [MaxLength(30, ErrorMessage = "Email должно иметь длину меньше 30 символов")]
    [MinLength(10, ErrorMessage = "Email должно иметь длину больше 10 символов")]
    public required string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Укажите пароль")]
    [MinLength(6, ErrorMessage = "Пароль должно иметь длину больше 6 символов")]
    public required string HashPassword { get; set; }

    public Role Role { get; set; }

    public List<Comment> Comments { get; set; } = new();

}
