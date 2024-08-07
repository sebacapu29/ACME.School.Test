using ACME.School.Domain.Entities;
using FluentValidation;

namespace ACME.School.Application.Validators
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(student => student.Name)
                        .NotEmpty().WithMessage("The student's name is required.");

            RuleFor(student => student.BirthDate)
                .NotEmpty().WithMessage("The student's date of birth is required.")
                .Must(IsAdult).WithMessage("Only adults can register.");
        }
        private bool IsAdult(DateTime dateOfBith) 
        {
            var toDay = DateTime.Today;

            if (dateOfBith <= toDay)
            {
                int edad = toDay.Year - dateOfBith.Year;

                if (dateOfBith.Month > toDay.Month)
                    --edad;
                return edad >= 18;
            }
            return false;
        }
    }
}
