namespace UserManager.Application.Dtos.User.Response;

public class UserDetailResponseDto
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public List<long> PermissionIds { get; set; } = null!;
    public List<string> GroupNames { get; set; } = null!;
}