using MediatR;
using System.Data.Entity.Core;
using System.Drawing;
using TaskАndProjectManagementSystem.Application.Contracts.Persistence;

namespace TaskАndProjectManagementSystem.Application;
public class DleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, BaseCommandResponse>
{
    public readonly IUnitOfWork _unitOfWork;

    public DleteProjectCommandHandler( IUnitOfWork unitOfWork )
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseCommandResponse> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var responce = new BaseCommandResponse();   

        var project = await _unitOfWork.ProjectsRepository.Get(request.ProjectId);

        if (project == null) 
        {
            throw new ObjectNotFoundException("Project not Found");
        }

        await _unitOfWork.ProjectsRepository.Delete(project);
        await _unitOfWork.SaveChaingesAsync();

        responce.Success = true;
        responce.Message = "project successfully deleted";
        responce.id= request.ProjectId; 
        return responce;    
    }
}
