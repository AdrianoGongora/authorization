using UserManager.Application.Dtos.User.Response;
using UserManager.Domain.Entities;

namespace UserManager.Application.Commons.Interfaces;

public interface IJwtTokenGenerator
{
    string GenerateToken(UserDetailResponseDto user);
}