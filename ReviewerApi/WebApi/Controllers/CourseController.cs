using Application.Features.Courses.Command;
using Application.Features.Courses.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Controllers;

[ApiController, Route("api/course")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpGet("all")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllCoursesQuery();
        var courses = await _mediator.Send(request);
        if (courses is null) return Ok("The list is empty");
        return Ok(courses);
    }

    [AllowAnonymous]
    [HttpPost("byName")]
    public async Task<IActionResult> GetCourseByName(GetCourseByNameQuery request)
    {
        var user = await _mediator.Send(request);
        if (user is not null)
            return Ok(user);
        return NotFound();
    }

    [AllowAnonymous]
    [HttpPost("byId")]
    public async Task<IActionResult> GetCourseById(GetCourseByIdQuery request)
    {
        var course = await _mediator.Send(request);
        if (course is not null)
            return Ok(course);
        return NotFound();
    }

    [AllowAnonymous]
    [HttpPost("add")]
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
    [HttpDelete("byId")]
    public async Task<IActionResult> DeleteCourseById(DeleteCourseByIdCommand command)
    {
        await _mediator.Send(command);
            return Ok("Course deleted.");
    }

    [AllowAnonymous]
    [HttpDelete("byName")]
    public async Task<IActionResult> DeleteCourseByName(DeleteCourseByNameCommand command)
    {
        await _mediator.Send(command);
        return Ok("Course deleted.");
    }

    [AllowAnonymous]
    [HttpPatch("byId")]
    public async Task<IActionResult> Update(UpdateCourseCommand command)
    {
        var response = await _mediator.Send(command);
        if (response is not null) return Ok(response);
        return BadRequest();
    }
}