using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Group.Command.UpdateGroup;

public class UpdateGroupCommand : IRequest<BaseResponse<bool>>
{
    public long Id { get; set; }
    public string Description { get; set; } = null!;
    public bool UpdateState { get; set; }
}