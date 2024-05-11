using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Dtos.User;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Role.Command.AddRolesUser;

public class AddRolesUserHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<AddRolesUserCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(AddRolesUserCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var userRoles = _mapper.Map<UserRolesDto>(request);
            await _unitOfWork.UserRepository.AddRolesUserAsync(userRoles);
            
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