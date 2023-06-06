using FluentValidation;
using static HFC.Domain.Staff;

namespace HFC.Application.Features.Staffs.DTOs.Validators
{
    public class IStaffDtoValidator : AbstractValidator<IStaffDto>
    {
        public IStaffDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.Title)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");

            RuleFor(p => p.About)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(300).WithMessage("{PropertyName} must not exceed {ComparisonValue} characters.");
            RuleFor(p => p.UserSector)
                  .Must(BeAValidSector).WithMessage("{PropertyName} is invalid.");
        }

        private bool BeAValidSector(Sector sector)
        {
            return Enum.IsDefined(typeof(Sector), sector);
        }
    }
}
