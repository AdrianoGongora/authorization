using UserManager.Domain.Entities;

namespace UserManager.Application.Interfaces.Persistence;

public interface IPermissionRepository
{
    Task SaveAsync(Permission permission);
    Task UpdateAsync(Permission permission, bool updateState);
}