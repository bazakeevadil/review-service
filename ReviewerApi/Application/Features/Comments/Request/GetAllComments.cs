namespace Application.Features.Reviews.Request;

public record GetAllReviewsQuery : IRequest<List<ReviewDto>> { }

internal class GetAllReviewsQueryHandler
    : IRequestHandler<GetAllReviewsQuery, List<ReviewDto>>
{
    private readonly IReviewRepository _reviewRepository;

    public GetAllReviewsQueryHandler(IReviewRepository reviewRepository)
    {
        _reviewRepository = reviewRepository;
    }

    public async Task<List<ReviewDto>> Handle(
        GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetAllAsync();
        
        var response = review.Adapt<List<ReviewDto>>();

        return response;
    }
}
