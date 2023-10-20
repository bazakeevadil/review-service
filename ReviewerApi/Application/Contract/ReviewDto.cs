namespace Application.Contract;

public class ReviewDto
{
    public required long Id { get; init; }
    public  long UserId { get; init; }
    public  User? User { get; init; }
    public  long CourseId { get; init; }
    public  Course? Course { get; init; }
    public required string? Content { get; init; }
    public required short Grade { get; init; }
}
