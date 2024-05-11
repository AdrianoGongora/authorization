using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Role.Command.CreateRole;

public class CreateRoleValidator(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreateRoleCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var role = _mapper.Map<Domain.Entities.Role>(request);
            await _unitOfWork.RoleRepository.SaveAsync(role);

            response.IsSuccess = true;
            response.Message = "Register success";
        }
        catch (Exception e)
        {
            response.Message = e.Message;
        }

        return response;
    }
}