using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskАndProjectManagementSystem.Application.DTO.Project.Valodator
{
    public class DeletePprojectDTOValidator : AbstractValidator<DeleteProjectDTO>
    {
        public DeletePprojectDTOValidator()
        {
            RuleFor(i => i.ProjectID)
                .NotEmpty().WithMessage("id must be not null");  
        }
    }
}
