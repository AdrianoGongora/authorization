namespace UserManager.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IRoleRepository RoleRepository { get; }
    IPermissionRepository PermissionRepository { get; }
    IGroupRepository GroupRepository { get; }
    Task SaveChanges();
}