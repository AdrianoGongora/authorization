using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Dtos.Group;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Group.Command.AddUsersGroup;

public class AddUsersGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<AddUsersGroupCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(AddUsersGroupCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var rolesPermission = _mapper.Map<GroupUsersDto>(request);
            await _unitOfWork.GroupRepository.AddUsersGroupAsync(rolesPermission);

            response.IsSuccess = true;
            response.Message = "Register Success";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}