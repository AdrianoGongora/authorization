using AutoMapper;
using UserManager.Application.UseCases.Users.Commands.CreateUser;
using UserManager.Domain.Entities;

namespace UserManager.Application.Mappings;

public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<CreateUserCmd, User>();
    }
}