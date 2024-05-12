using UserManager.Application.Dtos.Role;
using UserManager.Application.Dtos.User;
using UserManager.Domain.Entities;

namespace UserManager.Application.Interfaces.Persistence;

public interface IRoleRepository
{
    Task SaveAsync(Role role);
    Task UpdateAsync(RoleDto role);
    Task<long> RoleExistsAsync(string description, long idEntidad);
    Task AddPermissionsRoleAsync(RolesPermissionsDto userRoles);
    Task<List<RoleByEntidadDto>> GetPermissionByRoleAsync(long idEntidad);
}