using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Domain.Entities;

namespace UserManage.Infrastructure.Persistence.Context.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("RoleId");

        builder.Property(x => x.Description)
            .HasMaxLength(100);
    }
}