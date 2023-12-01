using MediatR;

namespace TaskАndProjectManagementSystem.Application.DTO.TaskDTO;
public class CreateTaskCommand : IRequest<BaseCommandResponse>
{

    public CreateTaskDTO createTask { get; set; }

}
