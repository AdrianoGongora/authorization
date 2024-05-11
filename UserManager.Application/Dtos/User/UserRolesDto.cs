namespace UserManager.Application.Dtos.User;

public class UserRolesDto
{
    public long UserId { get; set; }
    public HashSet<long>? RolesId { get; set; }
}