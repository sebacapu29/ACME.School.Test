using ACME.School.Application.Services;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using ACME.School.Domain.Services;
using Moq;

namespace ACME.School.Tests.Services
{
    public class RegistrationServiceTests
    {
        private readonly Mock<IStudentRepository> _mockStudentRepository;
        private readonly Mock<ICourseRepository> _mockCourseRepository;
        private readonly Mock<IPaymentGateway> _mockPaymentGateway;
        private readonly IRegistrationService _registrationService;
        public RegistrationServiceTests()
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
            _mockCourseRepository = new Mock<ICourseRepository>();
            _mockPaymentGateway = new Mock<IPaymentGateway>();
            _registrationService = new RegistrationService(_mockStudentRepository.Object, _mockCourseRepository.Object, _mockPaymentGateway.Object);
        }

        [Fact]
        public void Should_Throw_AgumentException_When_Student_Not_Found()
        {
            int studentId = 1;
            int courseId = 1;
            _mockStudentRepository.Setup(mockSR => mockSR.GetStudentById(studentId)).Returns((Student)null);

            Assert.Throws<ArgumentException>(() => _registrationService.RegisterStudentInCourse(studentId, courseId));
        }

        [Fact]
        public void Should_Throw_ArgumentException_When_Course_Not_Found()
        {
            int studentId = 1;
            int courseId = 1;
            var student = new Student(studentId, "Pedro", DateTime.Today.AddYears(-20));
            _mockStudentRepository.Setup(mockSR => mockSR.GetStudentById(studentId)).Returns(student);
            _mockCourseRepository.Setup(mockCR => mockCR.GetCourseById(courseId)).Returns((Course)null);

            Assert.Throws<ArgumentException>(() => _registrationService.RegisterStudentInCourse(studentId, courseId));
        }

        [Fact]
        public void Should_Return_True_When_Student_And_Course_Are_Found()
        {
            int studentId = 1;
            int courseId = 1;
            var student = new Student (studentId, "Pedro", DateTime.Today.AddYears(-20));
            var course = new Course(courseId, "Programming 1",100, DateTime.Today.AddDays(1), DateTime.Today.AddDays(10));
            _mockStudentRepository.Setup(mockSR => mockSR.GetStudentById(studentId)).Returns(student);
            _mockCourseRepository.Setup(mockCR => mockCR.GetCourseById(courseId)).Returns(course);
            _mockPaymentGateway.Setup(mockPG => mockPG.ProcessPayment(It.IsAny<decimal>())).Returns(true);
            var result = _registrationService.RegisterStudentInCourse(studentId, courseId);

            Assert.True(result);
            _mockCourseRepository.Verify(repo => repo.UpdateCourse(course), Times.Once);
        }
    }
}
