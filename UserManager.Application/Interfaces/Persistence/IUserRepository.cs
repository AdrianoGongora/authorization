using UserManager.Domain.Entities;

namespace UserManager.Application.Interfaces.Persistence;

public interface IUserRepository
{
    Task CreateAsync(User user);
    Task UpdateAsync(User user);
    Task DeleteAsync(long id);
    Task<User> UserByEmailAsync(string email);
}