using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Role.Command.UpdateRole;

public class UpdateRoleCommand : IRequest<BaseResponse<bool>>
{
    public string Description { get; set; } = null!;
    public int State { get; set; }
    public bool UpdateState { get; set; }
}