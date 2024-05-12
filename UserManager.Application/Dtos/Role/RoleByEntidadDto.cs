using UserManager.Application.Dtos.Permission;

namespace UserManager.Application.Dtos.Role;

public class RoleByEntidadDto
{
    public string Role { get; set; } = null!;
    public List<PermissionResponseDto> Permissions { get; set; } = null!;
}