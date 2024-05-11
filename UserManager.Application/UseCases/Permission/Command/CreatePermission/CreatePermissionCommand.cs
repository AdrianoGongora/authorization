using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Permission.Command.CreatePermission;

public class CreatePermissionCommand : IRequest<BaseResponse<bool>>
{
    public string Description { get; set; } = null!;
}