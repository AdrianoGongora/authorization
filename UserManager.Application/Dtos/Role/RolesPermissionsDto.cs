namespace UserManager.Application.Dtos.Role;

public class RolesPermissionsDto
{
    public long RoleId { get; set; }
    public HashSet<long> PermissionsId { get; set; }
}