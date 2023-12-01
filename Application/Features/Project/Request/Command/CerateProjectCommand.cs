using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.Project;

namespace TaskАndProjectManagementSystem.Application.Features.Project.Request.Command
{
    public class CerateProjectCommand : IRequest<BaseCommandResponse>
    {
        public CreateProjectDTO createProjectDTO {  get; set; }
    }
}
