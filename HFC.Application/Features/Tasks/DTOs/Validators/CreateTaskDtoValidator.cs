using FluentValidation;

namespace HFC.Application.Features.Tasks.DTOs.Validators
{
    public class CreateTaskDtoValidator: AbstractValidator<CreateTaskDto>
    {
        public CreateTaskDtoValidator()
        {
            Include(new ITaskDtoValidator());
        }
    }
}