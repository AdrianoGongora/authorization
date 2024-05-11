using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Permission.Command.AddPermissionsRoles;

public class AddPermissionsRolesCommand : IRequest<BaseResponse<bool>>
{
    public long RoleId { get; set; }
    public List<long> PermissionsId { get; set; }
}