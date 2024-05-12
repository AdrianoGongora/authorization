using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserManage.Infrastructure.Authentication;
using UserManager.Application.UseCases.Permission.Command.AddPermissionsRoles;
using UserManager.Application.UseCases.Role.Queries.RoleByEntidad;

namespace UserManager.Controllers;

[Route("api/[controller]")]
[Authorize]
public class Role : ControllerBase
{
    private readonly IMediator _mediator;

    public Role(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HasPermission(Permission.AddPermissions)]
    [HttpPost("Role")]
    public async Task<IActionResult> AddPermissionsRole([FromBody] AddPermissionsRolesCommand cmd)
    {
        var response = await _mediator.Send(cmd);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetRolesByEntidad([FromQuery] long idEntidad)
    {
        var qry = new RoleByEntidadQuery(idEntidad);
        var response = await _mediator.Send(qry);
        return Ok(response);
    }
}