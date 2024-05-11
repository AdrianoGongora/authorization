using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManage.Infrastructure.Authentication;
using UserManager.Application.UseCases.Permission.Command.AddPermissionsRoles;
using UserManager.Application.UseCases.Permission.Command.CreatePermission;

namespace UserManager.Controllers;


[Authorize]
[Route("api/[controller]")]
[ApiController]
public class Permissions : ControllerBase
{
    private readonly IMediator _mediator;

    public Permissions(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult>  CreatePermission([FromBody] CreatePermissionCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }
    
    [HasPermission(Permission.AddPermissions)]
    [HttpPost]
    public async Task<IActionResult>  AddPermissionsRole([FromBody] AddPermissionsRolesHandler cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }
}