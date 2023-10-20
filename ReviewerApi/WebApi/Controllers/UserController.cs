using Application.Features.Users.Commands;
using Application.Features.Users.Requests;
using Domain.Enum;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebApi.Controllers;

[ApiController, Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    [SwaggerOperation("Получает всех пользователей", "Позволяет получить всех пользователей. Только для админа!!!")]
    [SwaggerResponse(200, "Успешно получены")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> GetAll()
    {
        var request = new GetAllUsersQuery();

        var response = await _mediator.Send(request);

        return Ok(response);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("byemail")]
    [SwaggerOperation("Получает пользователя по имени", "Позволяет получить пользователя по имени. Только для админа!!!")]
    [SwaggerResponse(200, "Успешно получен")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> GetByEmail(
        string email)
    {
        var request = new GetUserByEmailQuery
        {
            Email = email,
        };

        var response = await _mediator.Send(request);

        return Ok(response ?? new object());
    }

    [Authorize(Roles = "Admin")]
    [HttpPost("byid")]
    [SwaggerOperation("Получает пользователя по id", "Позволяет получить пользователя по id. Только для админа!!!")]
    [SwaggerResponse(200, "Успешно получен")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> GetById(
       long id)
    {
        var request = new GetUserByIdQuery
        {
            Id = id,
        };

        var response = await _mediator.Send(request);

        return Ok(response ?? new object());
    }

    [Authorize(Roles = "Admin")]
    [HttpPatch("update")]
    [SwaggerOperation("Редактирует пользователя", "Позволяет редактировать пользователя. Только для админа!!!")]
    [SwaggerResponse(200, "Успешно редактировано")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> Update(
        string email,string password, Role role)
    {
        var request = new UpdateUserCommand
        {
            Email = email,
            Password = password,
            Role = role,
        };

        await _mediator.Send(request);

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("byname")]
    [SwaggerOperation("Удаляет пользователя по имени", "Позволяет удалить пользователя по имени. Только для админа!!!")]
    [SwaggerResponse(200, "Успешно удалено")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> Delete(
        string email)
    {
        var request = new DeleteUserCommand
        {
            Email = email,
        };

        await _mediator.Send(request);

        return Ok();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("byid")]
    [SwaggerOperation("Удаляет пользователя по Id", "Позволяет удалить пользователя по id. Только для админа!!!")]
    [SwaggerResponse(200, "Успешно удалено")]
    [SwaggerResponse(400, "Ошибка валидации")]
    public async Task<IActionResult> Delete(
        long id)
    {
        var request = new DeleteUserByIdCommand
        {
            Id = id,
        };

        await _mediator.Send(request);

        return Ok();
    }
}


