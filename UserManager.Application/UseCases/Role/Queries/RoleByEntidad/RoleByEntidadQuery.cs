using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Dtos.Role;

namespace UserManager.Application.UseCases.Role.Queries.RoleByEntidad;

public class RoleByEntidadQuery : IRequest<BaseResponse<List<RoleByEntidadDto>>>
{
    public long IdEntidad { get; set; }

    public RoleByEntidadQuery(long idEntidad)
    {
        IdEntidad = idEntidad;
    }
}