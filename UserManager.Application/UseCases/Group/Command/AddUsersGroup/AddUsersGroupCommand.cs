using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Group.Command.AddUsersGroup;

public class AddUsersGroupCommand : IRequest<BaseResponse<bool>>
{
    public long GroupId { get; set; }
    public HashSet<long> UsersId { get; set; }
}