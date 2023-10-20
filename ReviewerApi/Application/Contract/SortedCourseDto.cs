namespace Application.Contract;

public class SortedCourseDto
{
    public required CourseDto Course { get; init; }
    public required double AverageGrade  { get; init;}
}
