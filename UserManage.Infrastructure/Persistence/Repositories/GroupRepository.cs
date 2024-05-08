using Microsoft.EntityFrameworkCore;
using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Interfaces;
using UserManager.Application.Interfaces.Persistence;
using UserManager.Domain.Entities;

namespace UserManage.Infrastructure.Persistence.Repositories;

public class GroupRepository(ApplicationDbContext context) : IGroupRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task CreateAsync(Group group)
    {
        group.AuditCreateUser = 1;
        group.AuditCreateDate = DateTime.UtcNow;
        await _context.AddAsync(group);
        await _context.SaveChangesAsync();
    }

    public Task CreateWithUserAsync(Group group)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(Group group, bool updateState)
    {
        var groupUpdate = (await _context.Groups.FirstOrDefaultAsync(g => g.Id == group.Id))!;

        if (updateState)
        {
            groupUpdate.State = group.State;
        }
        else
        {
            groupUpdate.Description = group.Description;
        }

        groupUpdate.AuditUpdateUser = 1;
        groupUpdate.AuditUpdateDate = DateTime.UtcNow;
        await _context.SaveChangesAsync();
    }

    public async Task<long> GroupExistsAsync(string groupName, long idEntidad)
    {
        return await _context.Groups.Where(g => g.Description.Equals(groupName))
            .Select(g => g.Id)
            .FirstOrDefaultAsync();
    }
}