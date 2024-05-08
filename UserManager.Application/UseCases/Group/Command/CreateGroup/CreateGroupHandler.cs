using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Interfaces;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Group.Command.CreateGroup;

public class CreateGroupHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateGroupCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();
        try
        {
            var groupExist = await _unitOfWork.GroupRepository.GroupExistsAsync(request.Description,1);

            if (groupExist > 0)
            {
                response.IsSuccess = false;
                response.Message = "The group already exists";
            }
            
            var group = _mapper.Map<Domain.Entities.Group>(request);
            await _unitOfWork.GroupRepository.CreateAsync(group);

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