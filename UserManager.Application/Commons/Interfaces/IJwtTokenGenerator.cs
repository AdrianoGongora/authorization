using UserManager.Domain.Entities;

namespace UserManager.Application.Commons.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}