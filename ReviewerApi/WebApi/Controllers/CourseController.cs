using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Application.Features.Courses.Request.GetAllCourses;

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
        var request = new GetAllCoursesRequest();
        var courses = await _mediator.Send(request);
        if (courses is null) return Ok("The list is empty");
        return Ok(courses);
    }
}
