namespace UserManager.Application.Dtos.Role;

public class RoleDto
{
    public long RoleId { get; set; }
    public string Description { get; set; } = null!;
    public string State { get; set; } = null!;
    public bool UpdateState { get; set; }
}