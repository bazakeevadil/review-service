using Application.Features.Courses.Command;
using Application.Features.Courses.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers;

[ApiController, Route("api/courses")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllCoursesQuery();
        var courses = await _mediator.Send(request);
        if (courses is null) return Ok("The list is empty");
        return Ok(courses);
    }

    [AllowAnonymous]
    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetCourseByName(string name)
    {
        var request = new GetCourseByNameQuery() { Name = name };
        var user = await _mediator.Send(request);
        if (user is not null)
            return Ok(user);
        return NotFound();
    }

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCourseById(long id)
    {
        var request = new GetCourseByIdQuery() { Id = id };
        var course = await _mediator.Send(request);
        if (course is not null)
            return Ok(course);
        return NotFound();
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> AddCourse(CreateCourseCommand command)
    {
        if (command.Name.IsNullOrEmpty())
            return BadRequest("Name cannot be empty");
        if (command.Description.IsNullOrEmpty())
            return BadRequest("Description cannot be empty");
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCourseById(long id)
    {
        var request = new DeleteCourseByIdCommand { Id = id };
        await _mediator.Send(request);
        return NoContent();
    }

    [AllowAnonymous]
    [HttpDelete("by-name/{name}")]
    public async Task<IActionResult> DeleteCourseByName(string name)
    {
        var request = new DeleteCourseByNameCommand { Name = name };
        await _mediator.Send(request);
        return Ok("Course deleted.");
    }

    [AllowAnonymous]
    [HttpPatch]
    public async Task<IActionResult> Update(UpdateCourseCommand command)
    {
        var response = await _mediator.Send(command);
        if (response is not null) return Ok(response);
        return BadRequest();
    }
}