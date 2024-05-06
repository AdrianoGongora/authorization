using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Interfaces;
using BC = BCrypt.Net.BCrypt;

namespace UserManager.Application.UseCases.Users.Commands.CreateUser;

public class CreateUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateUserCmd, BaseResponse<bool>>
{
    public async Task<BaseResponse<bool>> Handle(CreateUserCmd request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var user = mapper.Map<Domain.Entities.User>(request);
            user.Password = BC.HashPassword(user.Password);
            await unitOfWork.UserRepository.CreateAsync(user);

            response.IsSuccess = true;
            response.Message = "Register Success";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}