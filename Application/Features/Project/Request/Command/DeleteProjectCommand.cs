using MediatR;
using TaskАndProjectManagementSystem.Application.Project;

namespace TaskАndProjectManagementSystem.Application;
public class DeleteProjectCommand : IRequest<BaseCommandResponse>
{
   public int ProjectId { get; set; }
}
