
using FluentValidation;

namespace HFC.Application.Features.Tasks.DTOs.Validators
{
    public class UpdateTaskDtoValidator : AbstractValidator<UpdateTaskDto>
    {
        public UpdateTaskDtoValidator()
        {
            Include(new ITaskDtoValidator());
            
            RuleFor(p => p.Id).NotNull().WithMessage("{PropertyName} must be present");

        }
    }
}