using AutoMapper;
using MediatR;
using TaskАndProjectManagementSystem.Application.CastomException;
using TaskАndProjectManagementSystem.Application.Contracts.Persistence;

namespace TaskАndProjectManagementSystem.Application;
public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateProjectCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _unitOfWork.ProjectsRepository.Get(request.UpdateProjectDTO.Id);
        if (project == null)
        {
            throw new NotFoundException(nameof(project),request.UpdateProjectDTO.Id);
        }

        _mapper.Map(request.UpdateProjectDTO, project);

        await _unitOfWork.ProjectsRepository.Update(project);
        await _unitOfWork.SaveChaingesAsync();

        var responce = new BaseCommandResponse()
        {
            id= request.UpdateProjectDTO.Id,    
            Success = true,
            Message = "Update"
        };

        return responce;

    }
}
