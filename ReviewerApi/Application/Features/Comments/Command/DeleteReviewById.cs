using Application.Shared;

namespace Application.Features.Reviews.Command;

public record DeleteReviewByIdCommand : IRequest
{
    public required long Id { get; init; }
}

internal class DeleteReviewByIdCommandHandler : IRequestHandler<DeleteReviewByIdCommand>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteReviewByIdCommandHandler(IReviewRepository reviewRepository, IUnitOfWork unitOfWork)
    {
        _reviewRepository = reviewRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(DeleteReviewByIdCommand command, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetById(command.Id);
        if (review is not null)
        {
            await _reviewRepository.DeleteByIdAsync(review.Id);
            await _unitOfWork.CommitAsync();
        }
    }
}
