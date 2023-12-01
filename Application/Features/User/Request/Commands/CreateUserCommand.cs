using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.DTO.User;

namespace TaskАndProjectManagementSystem.Application.Features.User.Request.Commands
{
    public class CreateUserCommand : IRequest<BaseCommandResponse>
    {
         public CreateUserDTO UserDTO { get; set; }
    }
}
