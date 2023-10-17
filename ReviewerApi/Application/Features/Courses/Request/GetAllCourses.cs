using Domain.Repositories;
using MediatR;

namespace Application.Features.Courses.Request;

public class GetAllCourses
{
    public record GetCourseResponse
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
    }

    public record GetAllCoursesRequest : IRequest<IEnumerable<GetCourseResponse>> { }

    internal class GetAllBookHandler : IRequestHandler<GetAllCoursesRequest, IEnumerable<GetCourseResponse>>
    {
        private readonly ICourseRepo _courseRepo;

        public GetAllBookHandler(ICourseRepo bookRepository)
        {
            _courseRepo = bookRepository;
        }

        public async Task<IEnumerable<GetCourseResponse>> Handle(GetAllCoursesRequest request, CancellationToken cancellationToken)
        {
            var Courses = await _courseRepo.GetAllAsync().ConfigureAwait(false);
            var response = new List<GetCourseResponse>();
            foreach (var course in Courses)
            {
                var result = new GetCourseResponse()
                {
                    Id = course.Id,
                    Name = course.Name,
                    Description = course.Description,
                };
                response.Add(result);
            }
            return response;
        }
    }
}
