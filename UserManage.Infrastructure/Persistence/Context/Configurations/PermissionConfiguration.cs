using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Domain.Entities;

namespace UserManage.Infrastructure.Persistence.Context.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("PermissionId");
        
        builder.Property(x => x.Description)
            .HasMaxLength(100);
    }
}