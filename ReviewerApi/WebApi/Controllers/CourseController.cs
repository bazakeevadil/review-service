using Application.Features.Courses.Command;
using Application.Features.Courses.Request;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllCoursesQuery();
        var courses = await _mediator.Send(request);
        if (courses is null) return Ok("The list is empty");
        return Ok(courses);
    }

    [AllowAnonymous]
    [HttpPost("AddCourse")]
    public async Task<IActionResult> AddCourse(CreateCourseCommand command)
    {
        if (command.Name.IsNullOrEmpty())
            return BadRequest("Title cannot be empty");
        if (command.Description.IsNullOrEmpty())
            return BadRequest("Description cannot be empty");
        var response = await _mediator.Send(command);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpDelete("DeleteCourseById")]
    public async Task<IActionResult> DeleteCourseById(DeleteCourseByIdCommand command)
    {
        await _mediator.Send(command);
            return Ok("Course deleted.");
    }
}