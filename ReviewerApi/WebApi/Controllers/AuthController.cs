using Application.Features.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[ApiController, Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    [SwaggerOperation("Для получения токена", "Позволяет получить токен для пользоваться функциями админа")]
    [SwaggerResponse(200, "Успешно получено")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> Login(LoginQuery query)
    {
        if (query.Email.IsNullOrEmpty()) return BadRequest("Email is null");
        if (query.Password.IsNullOrEmpty()) return BadRequest("Password is null");

        var token = await _mediator.Send(query) ?? string.Empty;
        return Ok(token);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    [SwaggerOperation("Регистрация", "Позволяет зарегистрироватся и получить доступ для просмотра")]
    [SwaggerResponse(200, "Успешно получено")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> Register(CreateUserCommand command)
    {
        if (command.Email.IsNullOrEmpty()) return BadRequest("Email is null");
        if (command.Password.IsNullOrEmpty()) return BadRequest("Password is null");

        var response = await _mediator.Send(command);

        return Ok(response);
    }
}
