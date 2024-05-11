using Microsoft.EntityFrameworkCore;
using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Dtos.User;
using UserManager.Application.Dtos.User.Response;
using UserManager.Application.Interfaces.Persistence;
using UserManager.Domain.Entities;

namespace UserManage.Infrastructure.Persistence.Repositories;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task CreateAsync(User user)
    {
        user.AuditCreateUser = 1;
        user.AuditCreateDate = DateTime.UtcNow;
        await _context.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public Task UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public async Task<UserDetailResponseDto> UserByEmailAsync(string email)
    {
        var userDetails = await _context.Users
            .AsNoTracking()
            .Where(u => u.Email.Equals(email) && u.State == "1" && u.AuditDeleteUser == null && u.AuditDeleteDate == null)
            .Select(u => new UserDetailResponseDto()
            {
                Name = u.FirstName,
                LastName = u.LastName,
                Email = u.Email,
                Password = u.Password,
                PermissionIds = u.RoleUsers
                    .SelectMany(ru => ru.Role.RolePermissions)
                    .Select(rp => rp.PermissionId)
                    .Distinct()
                    .ToList(),
                GroupNames = u.GroupUsers
                    .Select(gu => gu.Group.Description)
                    .ToList()
            })
            .FirstOrDefaultAsync();

        return userDetails!;
    }

    public async Task AddRolesUserAsync(UserRolesDto userRoles)
    {
        var user = await _context.Users
            .Include(u => u.RoleUsers)
            .FirstOrDefaultAsync(u => u.Id == userRoles.UserId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        foreach (var roleId in userRoles.RolesId!)
        {
            if (user.RoleUsers.Any(ru => ru.RoleId == roleId)) continue;
            var roleUser = new RoleUser
            {
                RoleId = roleId,
                UserId = userRoles.UserId,
                AuditCreateUser = 1,
                AuditCreateDate = DateTime.UtcNow
            };

            await _context.RoleUsers.AddAsync(roleUser);
        }
        await _context.SaveChangesAsync();
    }
}