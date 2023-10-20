using Application.Shared;

namespace Application.Features.Reviews.Command;

public record UpdateReviewCommand : IRequest<ReviewDto?>
{
    public required long Id { get; init; }
    public required string? Content { get; init; }
    public required short Grade { get; init; }
}

internal class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, ReviewDto?>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ReviewDto?> Handle(UpdateReviewCommand command, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetById(command.Id);
        if (review is not null)
        {
            review.Content = command.Content;
            review.Grade = command.Grade;

            _reviewRepository.Update(review);
            await _unitOfWork.CommitAsync();

            var response = new ReviewDto
            {
                Id = review.Id,
                Content = command.Content,
                Grade = command.Grade,              
            };
            return response;
        }
        return default;
    }
}