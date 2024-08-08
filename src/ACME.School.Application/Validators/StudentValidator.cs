using ACME.School.Application.DTOs.Requests;
using FluentValidation;

namespace ACME.School.Application.Validators
{
    public class StudentValidator : AbstractValidator<StudentRequest>
    {
        public StudentValidator()
        {
            RuleFor(student => student.Name)
                        .NotEmpty().WithMessage("The student's name is required.");

            RuleFor(student => student.DateOfBirth)
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
