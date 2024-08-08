using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.Services.Impl;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Application.Validators;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using Moq;

namespace ACME.School.Tests.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository> _mockStudentRepository;
        private readonly IStudentService _studentService;
        private readonly StudentValidator _validator;
        public StudentServiceTests()
        {
            _mockStudentRepository = new Mock<IStudentRepository>();
            _validator = new StudentValidator();
            _studentService = new StudentService(_mockStudentRepository.Object, _validator);
        }

        [Fact]
        public void Should_Add_Student()
        {
            var student = new StudentRequest { Name = "Pedro", DateOfBirth = DateTime.Today.AddYears(-20) };

            _studentService.RegisterStudent(student);

            _mockStudentRepository.Verify(repo => repo.AddStudent(It.IsAny<Student>()), Times.Once);
        }
    }
}
