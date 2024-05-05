namespace UserManager.Domain.Entities;

public class GroupUsers : BaseEntity
{
    public long UserId { get; set; }
    public long Groupid { get; set; }
    public virtual User User { get; set; } = null!;
    public virtual Group Group { get; set; } = null!;
}