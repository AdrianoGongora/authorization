namespace UserManager.Application.Dtos.Group;

public class GroupUsersDto
{
    public long GroupId { get; set; }
    public HashSet<long> UsersId { get; set; }
}