using ACME.School.Application.Services;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using ACME.School.Domain.Services;
using Moq;

namespace ACME.School.Tests.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _mockStudentRepository;
        private readonly IStudentService _studentService;

        public StudentServiceTests()
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
            _studentService = new StudentService(_mockStudentRepository.Object);
        }

        [Fact]
        public void Should_Add_Student()
        {
            var student = new Student(1, "Jorge", DateTime.Today.AddYears(-20));
           
            _studentService.RegisterStudent(student);

            _mockStudentRepository.Verify(repo => repo.AddStudent(student), Times.Once);
        }
    }
}
