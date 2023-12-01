using MediatR;
using TaskАndProjectManagementSystem.Application.DTO.Project;

namespace TaskАndProjectManagementSystem.Application;
public class UpdateProjectCommand : IRequest<BaseCommandResponse>
{
   public UpdateProjectDTO UpdateProjectDTO { get; set; }
}
