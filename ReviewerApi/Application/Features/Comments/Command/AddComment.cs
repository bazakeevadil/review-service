using Application.Shared;

namespace Application.Features.Reviews.Command;

public record CreateReviewCommand : IRequest<ReviewDto>
{
    public required string Content { get; init; }
    public long UserId { get; init; }
    public required short Grade { get; init; }
}

internal class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, ReviewDto>
{
    private readonly IReviewRepository _reviewRepo;
    private readonly IUnitOfWork _unitOfWork;

    public CreateReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepo = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ReviewDto> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = new Review
        {
            Content = request.Content,
            Grade = request.Grade,
            UserId = request.UserId,
        };

        _reviewRepo.Add(review);
        await _unitOfWork.CommitAsync();

        var response = new ReviewDto
        {
            Id = review.Id,
            Content = review.Content,
            Grade = request.Grade,
            UserId = request.UserId,
        };

        return response;
    }
}