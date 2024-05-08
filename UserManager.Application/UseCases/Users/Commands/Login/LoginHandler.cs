using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Commons.Interfaces;
using UserManager.Application.Interfaces;
using UserManager.Application.Interfaces.Persistence;
using BC = BCrypt.Net.BCrypt;

namespace UserManager.Application.UseCases.Users.Commands.Login;

public class LoginHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
    : IRequestHandler<LoginCommand, BaseResponse<string>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;

    public async Task<BaseResponse<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<string>();
        try
        {
            var user = await _unitOfWork.UserRepository.UserByEmailAsync(request.Email);

            if (user is null)
            {
                response.IsSuccess = false;
                response.Message = "El usuario y/o contrasena es incorrecto.";
                return response;
            }

            if (BC.Verify(request.Password, user.Password))
            {
                response.IsSuccess = true;
                response.Data = _jwtTokenGenerator.GenerateToken(user);
                response.Message = "Token generado correctamente";
            }
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}