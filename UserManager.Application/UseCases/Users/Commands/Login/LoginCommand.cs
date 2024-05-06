using MediatR;
using UserManager.Application.Commons.Bases;

namespace UserManager.Application.UseCases.Users.Commands.Login;

public class LoginCommand : IRequest<BaseResponse<string>>
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}