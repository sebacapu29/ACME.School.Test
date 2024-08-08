using ACME.School.Domain.Entities;
using ACME.School.Application.Validators;
using FluentValidation.TestHelper;
using ACME.School.Tests.Repositories;
using ACME.School.Application.DTOs.Requests;

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
            var student = new StudentRequest { Name = string.Empty , DateOfBirth = DateTime.Today.AddYears(-20) };
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(s => s.Name)
                  .WithErrorMessage("The student's name is required.");
        }

        [Fact]
        public void Should_Have_Error_When_BirthDate_Is_Empty()
        {
            var student = new StudentRequest { Name = "Jorge", DateOfBirth = new DateTime() };
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(s => s.DateOfBirth)
                  .WithErrorMessage("The student's date of birth is required.");
        }

        [Fact]
        public void Should_Have_Error_When_Student_Is_Not_Adult()
        {
            var student = new StudentRequest { Name = "Pedro", DateOfBirth = DateTime.Today.AddYears(-17) };
            var result = _validator.TestValidate(student);
            result.ShouldHaveValidationErrorFor(s => s.DateOfBirth)
                  .WithErrorMessage("Only adults can register.");
        }
    }
}
