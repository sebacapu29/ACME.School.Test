using ACME.School.Domain.Entities;
using ACME.School.Application.Validators;
using FluentValidation.TestHelper;

namespace ACME.School.Tests.Validators
{
    public class StudentValidatorTests
    {
        private readonly StudentValidator _validator;

        public StudentValidatorTests()
        {
            _validator = new StudentValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var student = new Student(0, string.Empty, DateTime.Today.AddYears(-20));
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(s => s.Name)
                  .WithErrorMessage("The student's name is required.");
        }

        [Fact]
        public void Should_Have_Error_When_BirthDate_Is_Empty()
        {
            var student = new Student (0, "", new DateTime());
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(s => s.BirthDate)
                  .WithErrorMessage("The student's date of birth is required.");
        }

        [Fact]
        public void Should_Have_Error_When_Student_Is_Not_Adult()
        {
            var student = new Student(1, "Pedro", DateTime.Today.AddYears(-17) );
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(s => s.BirthDate)
                  .WithErrorMessage("Only adults can register.");
        }
    }
}
