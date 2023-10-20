namespace Application.Features.Reviews.Request;

public record GetReviewByIdQuery : IRequest<ReviewDto?>
{
    public long Id { get; init; }
}

internal class GetReviewByIdQueryHandler : IRequestHandler<GetReviewByIdQuery, ReviewDto?>
{
    private readonly IReviewRepository _reviewRepository;

    public GetReviewByIdQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<ReviewDto?> Handle(GetReviewByIdQuery request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetById(request.Id);
       
        if (review is not null)
        {
           if (review.Course?.Id == review.CourseId)
            {
                var response = new ReviewDto
                {
                    CourseId = review.CourseId,
                    Id = request.Id,
                    Content = review.Content,
                    Grade = review.Grade,
                };
                return response;
            }
          
        }
        return default;
    }
}
