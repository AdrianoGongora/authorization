namespace UserManager.Domain.Entities;

public class User : BaseEntity
{
    public User()
    {
        RoleUsers = new HashSet<RoleUser>();
        GroupUsers = new HashSet<GroupUsers>();
    }

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public virtual ICollection<RoleUser> RoleUsers { get; set; }
    public virtual ICollection<GroupUsers> GroupUsers { get; set; }
}