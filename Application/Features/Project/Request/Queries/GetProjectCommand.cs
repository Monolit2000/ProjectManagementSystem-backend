using MediatR;
using TaskАndProjectManagementSystem.Application.DTO.Project;

namespace TaskАndProjectManagementSystem.Application;
public class GetProjectCommand : IRequest<BaseCommandResponse>
{
  public ProjectDTO projectDTO { get; set; }    
}
