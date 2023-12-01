using FluentValidation;
using MediatR;
using System.ComponentModel.DataAnnotations;
using TaskАndProjectManagementSystem.Application.Contracts.Persistence;
using TaskАndProjectManagementSystem.Application.Project;

namespace TaskАndProjectManagementSystem.Application;
public class GetProjectCommandHandler : IRequestHandler<GetProjectCommand, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IValidator<CreateProjectDTO> _validator;
    public GetProjectCommandHandler(IUnitOfWork unitOfWork, IValidator<CreateProjectDTO> validator)
    {
        _unitOfWork = unitOfWork;     
        _validator = validator; 
    }

    public Task<BaseCommandResponse> Handle(GetProjectCommand request, CancellationToken cancellationToken)
    {


        throw new NotImplementedException();
    }
}
