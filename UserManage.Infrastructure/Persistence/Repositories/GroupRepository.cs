using Microsoft.EntityFrameworkCore;
using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Dtos.Group;
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

    public async Task AddUsersGroupAsync(GroupUsersDto groupUsersDto)
    {
        var groupUpdate = await _context.Groups.Include(group => group.GroupUsers).FirstOrDefaultAsync(x => x.Id == groupUsersDto.GroupId);
        if (groupUsersDto == null)
        {
            throw new Exception("User not found");
        }


        foreach (var userId in groupUsersDto.UsersId)
        {
            if (groupUpdate!.GroupUsers.Any(ru => ru.UserId == userId)) continue;
            var groupUser = new GroupUsers()
            {
                UserId = userId,
                Groupid = groupUsersDto.GroupId,
                AuditCreateUser = 1,
                AuditCreateDate = DateTime.UtcNow
            };

            await _context.GroupUsers.AddAsync(groupUser);
        }

        await _context.SaveChangesAsync();
    }
}