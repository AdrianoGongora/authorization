using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Dtos.Role;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Role.Queries.RoleByEntidad;

public class RoleByEntidadHandler(IUnitOfWork unitOfWork)
    : IRequestHandler<RoleByEntidadQuery, BaseResponse<List<RoleByEntidadDto>>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<BaseResponse<List<RoleByEntidadDto>>> Handle(RoleByEntidadQuery request,
        CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<RoleByEntidadDto>>();
        try
        {
            var rolesByEntidad = await _unitOfWork.RoleRepository.GetPermissionByRoleAsync(request.IdEntidad);
            response.IsSuccess = true;
            response.Data = rolesByEntidad;
            response.Message = "Role of the entidad";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}