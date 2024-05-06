using Microsoft.EntityFrameworkCore;
using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Interfaces;
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

    public async Task<User> UserByEmailAsync(string email)
    {
        var user = await _context.Users
        .AsNoTracking()
        .FirstOrDefaultAsync(x => x.Email.Equals(email)
            && x.State == "1" && x.AuditDeleteUser == null
            && x.AuditDeleteDate == null);

        return user!;
    }
}