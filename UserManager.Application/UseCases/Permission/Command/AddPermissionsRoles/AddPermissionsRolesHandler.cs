using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Dtos.Role;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Permission.Command.AddPermissionsRoles;

public class AddPermissionsRolesHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<AddPermissionsRolesCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(AddPermissionsRolesCommand request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var rolesPermission = _mapper.Map<RolesPermissionsDto>(request);
            await _unitOfWork.RoleRepository.AddPermissionsRoleAsync(rolesPermission);

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