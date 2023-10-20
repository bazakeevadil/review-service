using Application.Features.Comments.Command;
using Application.Features.Comments.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers;

[ApiController, Route("api/comment")]
public class CommentController : ControllerBase
{
    private readonly IMediator _mediator;

    public CommentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet("All")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllCommentsQuery();
        var comments = await _mediator.Send(request);
        if (comments is null) return Ok("The list is empty");
        return Ok(comments);
    }

    [AllowAnonymous]
    [HttpPost("ById")]
    public async Task<IActionResult> GetCommentById(GetCommentByIdQuery request)
    {
        var comment = await _mediator.Send(request);
        if (comment is not null)
            return Ok(comment);
        return NotFound();
    }

    [AllowAnonymous]
    [HttpPost("Add")]
    public async Task<IActionResult> AddComment(CreateCommentCommand command)
    {
        if (command.Content.IsNullOrEmpty())
            return BadRequest("Content cannot be empty");
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpDelete("CommentById")]
    public async Task<IActionResult> DeleteCommentById(DeleteCommentByIdCommand command)
    {
        await _mediator.Send(command);
        return Ok("Comment deleted.");
    }

    [AllowAnonymous]
    [HttpPatch("ById")]
    public async Task<IActionResult> UpdateCommentById(UpdateCommentCommand command)
    {
        var response = await _mediator.Send(command);
        if (response is not null) return Ok(response);
        return BadRequest();
    }
}
