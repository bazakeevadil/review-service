using Application.Shared;

namespace Application.Features.Courses.Command;


public record CreateCourseCommand : IRequest<CourseDto>
{
    public required string Name { get; init; }
    public string? Description { get; init; }
}

internal class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseDto>
{
    private readonly ICourseRepository _courseRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
    {
        _courseRepo = courseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CourseDto> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = new Course
        {
            Name = request.Name,
            Description = request.Description,
        };

        _courseRepo.Add(course);
        await _unitOfWork.CommitAsync();

        var response = new CourseDto
        {
            Id = course.Id,
            Name = request.Name,
            Description = request.Description,
        };

        return response;
    }
}

