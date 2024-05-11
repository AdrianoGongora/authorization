using Microsoft.EntityFrameworkCore;
using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Interfaces;
using UserManager.Application.Interfaces.Persistence;
using UserManager.Domain.Entities;

namespace UserManage.Infrastructure.Persistence.Repositories;

public class PermissionRepository(ApplicationDbContext context) : IPermissionRepository
{
    private readonly ApplicationDbContext _context = context;


    public async Task SaveAsync(Permission permission)
    {
        permission.AuditCreateUser = 1;
        permission.AuditCreateDate = DateTime.UtcNow;

        await _context.AddAsync(permission);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Permission permission, bool updateState)
    {
        var permissionUpdate = await _context.Permissions.FirstOrDefaultAsync(x => x.Id == permission.Id);
    }
}