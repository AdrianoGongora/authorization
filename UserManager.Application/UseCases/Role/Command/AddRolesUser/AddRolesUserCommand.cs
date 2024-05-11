using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Role.Command.AddRolesUser;

public class AddRolesUserCommand : IRequest<BaseResponse<bool>>
{
    public long UserId { get; set; }
    public required List<long> RolesId { get; set; }
}