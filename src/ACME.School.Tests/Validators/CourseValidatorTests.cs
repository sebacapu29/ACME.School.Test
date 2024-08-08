using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.Validators;
using ACME.School.Domain.Entities;
using FluentValidation.TestHelper;

namespace ACME.School.Tests.Validators
{
    public class CourseValidatorTests
    {
        private readonly CourseValidator _validator;

        public CourseValidatorTests()
        {
            _validator = new CourseValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Empty()
        {
            var course = new CourseRequest { Name = string.Empty, RegistrationFee = 100, StartDate = DateTime.Today.AddDays(1), EndDate = DateTime.Today.AddDays(10)};
            var result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(c => c.Name)
                  .WithErrorMessage("The course name is required.");
        }

        [Fact]
        public void Should_Have_Error_When_RegistrationFee_Is_Negative()
        {
            var course = new CourseRequest { Name = "Programming 1", RegistrationFee = -100, StartDate = DateTime.Today.AddDays(1), EndDate = DateTime.Today.AddDays(10) };
            var result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(c => c.RegistrationFee)
                  .WithErrorMessage("The registration fee cannot be negative.");
        }

        [Fact]
        public void Should_Have_Error_When_StartDate_Is_After_EndDate()
        {
            var course = new CourseRequest { Name = "Programming 1", RegistrationFee = 100, StartDate = DateTime.Today.AddDays(10), EndDate = DateTime.Today.AddDays(1) };
            var result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(c => c.StartDate)
                  .WithErrorMessage("The start date must be less than the end date.");
        }

        [Fact]
        public void Should_Have_Error_When_EndDate_Is_Before_StartDate()
        {

            var course = new CourseRequest { Name = "Programming 1", RegistrationFee = 100, StartDate = DateTime.Today.AddDays(10), EndDate = DateTime.Today.AddDays(1) };

            var result = _validator.TestValidate(course);
            result.ShouldHaveValidationErrorFor(c => c.EndDate)
                  .WithErrorMessage("The end date must be greater than the start date.");
        }
    }
}
