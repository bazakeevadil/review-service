using Application.Features.Reviews.Command;
using Application.Features.Reviews.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers;

[ApiController, Route("api/reviews")]
public class ReviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public ReviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllReviewsQuery();
        var reviews = await _mediator.Send(request);
        if (reviews is null) return Ok("The list is empty");
        return Ok(reviews);
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetReviewById(long id)
    {
        var request = new GetReviewByIdQuery { Id = id };
        var review = await _mediator.Send(request);
        if (review is not null)
            return Ok(review);
        return NotFound();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> AddReview(CreateReviewCommand command)
    {
        if (command.Content.IsNullOrEmpty())
            return BadRequest("Content cannot be empty");
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReviewById(long id)
    {
        var request = new DeleteReviewByIdCommand { Id = id };
        await _mediator.Send(request);
        return NoContent();
    }

    [AllowAnonymous]
    [HttpPatch]
    public async Task<IActionResult> UpdateReviewById(UpdateReviewCommand command)
    {
        var response = await _mediator.Send(command);
        if (response is not null) return Ok(response);
        return BadRequest();
    }
}
