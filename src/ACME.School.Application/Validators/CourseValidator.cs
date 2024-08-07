using ACME.School.Domain.Entities;
using FluentValidation;

namespace ACME.School.Application.Validators
{
    public class CourseValidator : AbstractValidator<Course>
    {
        public CourseValidator()
        {
            RuleFor(course => course.Name)
                .NotEmpty().WithMessage("The course name is required.");

            RuleFor(course => course.RegistrationFee)
                .GreaterThanOrEqualTo(0).WithMessage("The registration fee cannot be negative.");

            RuleFor(course => course.StartDate)
                .LessThan(course => course.EndDate).WithMessage("The start date must be less than the end date.");

            RuleFor(course => course.EndDate)
                .GreaterThan(course => course.StartDate).WithMessage("The end date must be greater than the start date.");
        }
    }
}
