using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Interfaces;

namespace UserManage.Infrastructure.Persistence.Repositories;

public class GroupRepository(ApplicationDbContext context) : IGroupRepository
{
    private readonly ApplicationDbContext _context = context;
}