using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UserManager.Domain.Entities;

namespace UserManage.Infrastructure.Persistence.Context.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("UserId");
        
        builder.HasMany(u => u.GroupUsers)
            .WithOne(gu => gu.User)
            .HasForeignKey(gu => gu.UserId);

        builder.Property(x => x.FirstName)
            .HasMaxLength(50);
        
        builder.Property(x => x.LastName)
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .HasMaxLength(150);
    }
}