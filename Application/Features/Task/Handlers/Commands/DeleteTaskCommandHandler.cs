using MediatR;

namespace TaskАndProjectManagementSystem.Application;
public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, BaseCommandResponse>
{
    public Task<BaseCommandResponse> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
