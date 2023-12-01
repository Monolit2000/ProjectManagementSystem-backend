using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.Features.User.Request.Commands;

namespace TaskАndProjectManagementSystem.Application.Features.User.Hendlers.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, BaseCommandResponse>
    {
        public Task<BaseCommandResponse> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
