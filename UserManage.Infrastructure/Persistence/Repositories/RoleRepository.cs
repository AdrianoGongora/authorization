using Microsoft.EntityFrameworkCore;
using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Dtos.Role;
using UserManager.Application.Interfaces.Persistence;
using UserManager.Domain.Entities;

namespace UserManage.Infrastructure.Persistence.Repositories;

public class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task SaveAsync(Role role)
    {
        role.AuditCreateUser = 1;
        role.AuditCreateDate = DateTime.UtcNow;
        await _context.AddAsync(role);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(RoleDto role)
    {
        var roleUpdate = (await _context.Roles.FirstOrDefaultAsync(r => r.Id == role.RoleId))!;

        if (role.UpdateState)
        {
            roleUpdate.State = role.State;
        }
        else
        {
            roleUpdate.Description = role.Description;
        }

        roleUpdate.AuditUpdateDate = DateTime.UtcNow;
        roleUpdate.AuditUpdateUser = 1;

        await _context.SaveChangesAsync();
    }

    public async Task<long> RoleExistsAsync(string description, long idEntidad)
    {
        return await _context.Roles
            .AsNoTracking()
            .Where(r => r.Description == description
                        && r.State == "1"
                        && r.AuditDeleteUser == null
                        && r.AuditDeleteDate == null)
            .Select(r => r.Id)
            .FirstOrDefaultAsync();
    }

    public async Task AddPermissionsRoleAsync(RolesPermissionsDto rolesPermissions)
    {
        var permissions = await _context.RolePermissions
            .Where(rp => rp.RoleId == rolesPermissions.RoleId)
            .Select(rp => rp.PermissionId)
            .ToListAsync();

        if (permissions == null)
        {
            throw new Exception("Role not found");
        }

        foreach (var permissionId in rolesPermissions.PermissionsId)
        {
            if (permissions.Any(rp => rp == permissionId)) continue;
            var rolePermission = new RolePermission
            {
                RoleId = rolesPermissions.RoleId,
                PermissionId = permissionId,
                AuditCreateUser = 1,
                AuditCreateDate = DateTime.UtcNow
            };

            await _context.RolePermissions.AddAsync(rolePermission);
        }

        await _context.SaveChangesAsync();
    }
}