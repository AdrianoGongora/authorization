using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Role.Command.CreateRole;

public class CreateRoleCommand : IRequest<BaseResponse<bool>>
{
    public string Description { get; set; } = null!;
}