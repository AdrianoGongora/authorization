using UserManager.Application.Dtos.User;
using UserManager.Application.Dtos.User.Response;
using UserManager.Domain.Entities;

namespace UserManager.Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(long id);
    Task<UserDetailResponseDto> UserByEmailAsync(string email);
    Task AddRolesUserAsync(UserRolesDto userRoles);

}