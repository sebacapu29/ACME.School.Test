using ACME.School.Application.Services;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using ACME.School.Domain.Services;
using Moq;

namespace ACME.School.Tests.Services
{
    public class CourseServiceTests
    {
        private readonly Mock<ICourseRepository> _mockCourseRepository;
        private readonly ICourseService _courseService;

        public CourseServiceTests()
        {
            _mockCourseRepository = new Mock<ICourseRepository>();
            _courseService = new CourseService(_mockCourseRepository.Object);
        }

        [Fact]
        public void Should_Add_Course()
        {
            var course = new Course(1, "Cooking 1", 100, DateTime.Today.AddDays(1), DateTime.Today.AddDays(10));

            _courseService.RegisterCourse(course);

            _mockCourseRepository.Verify(repo => repo.AddCourse(course), Times.Once);
        }
    }
}
