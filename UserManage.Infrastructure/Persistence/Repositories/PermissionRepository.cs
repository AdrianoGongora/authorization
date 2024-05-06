using UserManage.Infrastructure.Persistence.Context;
using UserManager.Application.Interfaces;

namespace UserManage.Infrastructure.Persistence.Repositories;

public class PermissionRepository(ApplicationDbContext context) : IPermissionRepository
{
    private readonly ApplicationDbContext _context = context;
}