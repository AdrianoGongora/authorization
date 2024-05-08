using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Group.Command.CreateGroup;

public class CreateGroupCommand : IRequest<BaseResponse<bool>>
{
    public string Description { get; set; } = null!;
}