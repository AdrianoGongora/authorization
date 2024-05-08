using UserManager.Domain.Entities;

namespace UserManager.Application.Interfaces.Persistence;

public interface IGroupRepository
{
    Task CreateAsync(Group group);
    Task CreateWithUserAsync(Group group);
    Task UpdateAsync(Group group, bool updateState);
    Task<long> GroupExistsAsync(string groupName, long idEntidad);
}