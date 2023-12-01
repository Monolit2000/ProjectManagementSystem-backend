using FluentValidation;
using TaskАndProjectManagementSystem.Application.Project;

public class CreateProjectDTOValidator : AbstractValidator<CreateProjectDTO>
{
    public CreateProjectDTOValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty()
            .WithMessage("Project name is required.")
            .MaximumLength(25)
            .WithMessage("Project name cannot be longer than 255 characters.");

        RuleFor(p => p.Description)
            .NotEmpty()
            .WithMessage("Project description is required.")
            .MaximumLength(1000)
            .WithMessage("Project description cannot be longer than 10000 characters.");

        RuleFor(p => p.StartDate)
            .LessThanOrEqualTo(p => p.EndDate)
            .WithMessage("Start date must be less than or equal to end date.");

        RuleFor(p => p.Tasks)
            .NotNull()
            .WithMessage("Tasks list cannot be null.")
            .NotEmpty()
            .WithMessage("Tasks list cannot be empty.");
    }
}