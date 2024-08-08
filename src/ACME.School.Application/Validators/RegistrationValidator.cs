using ACME.School.Application.DTOs.Requests;
using FluentValidation;

namespace ACME.School.Application.Validators
{
    public class RegistrationValidator: AbstractValidator<RegistrationRequest>
    {
        public RegistrationValidator()
        {
            RuleFor(registration => registration.CourseId)
                .NotEmpty().WithMessage("The course id is required.")
                .GreaterThan(0).WithMessage("The course id cannot be negative");
            RuleFor(registration => registration.StudentId)
                 .NotEmpty().WithMessage("The student id is required.")
                 .GreaterThan(0).WithMessage("The student id cannot be negative");
        }
    }
}
