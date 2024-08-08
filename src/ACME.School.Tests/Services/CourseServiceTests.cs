using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.Services.Impl;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Application.Validators;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using Moq;

namespace ACME.School.Tests.Services
{
    public class CourseServiceTests
    {
        private readonly Mock<ICourseRepository> _mockCourseRepository;
        private readonly ICourseService _courseService;
        private readonly CourseValidator _validator;
        public CourseServiceTests()
        {
            _validator = new CourseValidator();
            _mockCourseRepository = new Mock<ICourseRepository>();
            _courseService = new CourseService(_mockCourseRepository.Object, _validator);
        }

        [Fact]
        public void Should_Add_Course()
        {
            var course = new CourseRequest { Name = "Cooking 1", RegistrationFee = 100, StartDate = DateTime.Today.AddDays(1), EndDate = DateTime.Today.AddDays(10) };

            _courseService.RegisterCourse(course);

            _mockCourseRepository.Verify(repo => repo.AddCourse(It.IsAny<Course>()), Times.Once);
        }
    }
}
