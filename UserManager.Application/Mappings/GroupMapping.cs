using AutoMapper;
using UserManager.Application.UseCases.Group.Command.CreateGroup;
using UserManager.Application.UseCases.Group.Command.UpdateGroup;
using UserManager.Domain.Entities;

namespace UserManager.Application.Mappings;

public class GroupMapping : Profile
{
    public GroupMapping()
    {
        CreateMap<CreateGroupCommand, Group>();
        CreateMap<UpdateGroupCommand, Group>();
    }
}