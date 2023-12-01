using MediatR;

namespace TaskАndProjectManagementSystem.Application;
public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, BaseCommandResponse>
{
    public Task<BaseCommandResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
