using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserManager.Application.UseCases.Users.Commands.CreateUser;

namespace UserManager.Controllers;

[Route("api/[controller]")]
[ApiController]
public class User : ControllerBase
{
    private readonly IMediator _mediator;

    public User(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("Create")]
    public async Task<IActionResult> UserCreate([FromBody] CreateUserCmd command)
    {
        var response = await _mediator.Send(command);
        return Ok(response);
    }
}