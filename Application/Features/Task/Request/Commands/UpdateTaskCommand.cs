using MediatR;
using TaskАndProjectManagementSystem.Application.DTO.TaskDTO;

namespace TaskАndProjectManagementSystem.Application;
public class UpdateTaskCommand : IRequest<BaseCommandResponse>
{
    public UpdateTaskDTO updateTask { get; set; }
}
