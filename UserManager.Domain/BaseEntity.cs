namespace UserManager.Domain;

public abstract class BaseEntity
{
    public long Id { get; set; }
    public string? State { get; set; }
    public int AuditCreateUser { get; set; }
    public DateTime AuditCreateDate { get; set; }
    public int? AuditUpdateUser { get; set; }
    public DateTime? AuditUpdateDate { get; set; }
    public int? AuditDeleteUser { get; set; }
    public DateTime? AuditDeleteDate { get; set; }
}