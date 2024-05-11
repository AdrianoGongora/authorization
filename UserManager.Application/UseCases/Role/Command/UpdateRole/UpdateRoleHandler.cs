using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Dtos.Group;
using UserManager.Application.Dtos.Role;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Role.Command.UpdateRole;

public class UpdateRoleHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<UpdateRoleCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var rolesPermission = _mapper.Map<RoleDto>(request);
            //await _unitOfWork.RoleRepository.UpdateAsync(rolesPermission);

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