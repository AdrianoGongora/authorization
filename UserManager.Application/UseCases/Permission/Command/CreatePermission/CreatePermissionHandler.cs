using AutoMapper;
using MediatR;
using UserManager.Application.Commons.Bases;
using UserManager.Application.Interfaces.Persistence;

namespace UserManager.Application.UseCases.Permission.Command.CreatePermission;

public class CreatePermissionHandler(IUnitOfWork unitOfWork, IMapper mapper)
    : IRequestHandler<CreatePermissionCommand, BaseResponse<bool>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _mapper = mapper;

    public async Task<BaseResponse<bool>> Handle(CreatePermissionCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<bool>();

        try
        {
            var permission = _mapper.Map<Domain.Entities.Permission>(request);
            await _unitOfWork.PermissionRepository.SaveAsync(permission);

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