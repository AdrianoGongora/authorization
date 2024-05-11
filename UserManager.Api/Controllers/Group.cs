using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManage.Infrastructure.Authentication;
using UserManager.Application.UseCases.Group.Command.CreateGroup;
using UserManager.Application.UseCases.Group.Command.UpdateGroup;

namespace UserManager.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class Group : ControllerBase
{
    private readonly IMediator _mediator;

    public Group(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGroup([FromBody] CreateGroupCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }

    
    [HasPermission(Permission.ReadMember)]
    [HttpPut]
    public async Task<IActionResult> UpdateGroup([FromBody] UpdateGroupCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }
}