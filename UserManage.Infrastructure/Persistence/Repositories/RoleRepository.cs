using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Interfaces;
using UserManager.Application.Interfaces.Persistence;

namespace UserManage.Infrastructure.Persistence.Repositories;

public class RoleRepository(ApplicationDbContext context) : IRoleRepository
{
    private readonly ApplicationDbContext _context = context;
}