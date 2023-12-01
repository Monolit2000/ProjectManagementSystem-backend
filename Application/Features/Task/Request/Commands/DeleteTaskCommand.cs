using MediatR;
using TaskАndProjectManagementSystem.Application.TaskDTO;

namespace TaskАndProjectManagementSystem.Application;
public class DeleteTaskCommand : IRequest<BaseCommandResponse>
{
   public DeleteTaskDTO deleteTask {  get; set; }
}
