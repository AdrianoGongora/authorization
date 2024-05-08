using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Interfaces;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Group.Command.UpdateGroup;

public class UpdateGroupHandler(IMapper mapper, IUnitOfWork unitOfWork)
    : IRequestHandler<UpdateGroupCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var groupExist = await _unitOfWork.GroupRepository.GroupExistsAsync(request.Description, 1);

            if (groupExist > 0 && groupExist == request.Id)
            {
                response.IsSuccess = false;
                response.Message = "The group already exists";
            }

            var group = _mapper.Map<Domain.Entities.Group>(request);
            await _unitOfWork.GroupRepository.UpdateAsync(group, request.UpdateState);

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