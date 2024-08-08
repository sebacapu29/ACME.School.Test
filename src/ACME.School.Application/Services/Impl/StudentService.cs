using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.DTOs.Responses;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Application.Validators;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using FluentValidation;

namespace ACME.School.Application.Services.Impl
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IValidator<StudentRequest> _studentValidator;
        public StudentService(IStudentRepository studentRepository, IValidator<StudentRequest> studentValidator)
        {
            _studentRepository = studentRepository;
            _studentValidator = studentValidator;
        }
        public void RegisterStudent(StudentRequest studentRequest)
        {
            _studentValidator.Validate(studentRequest);
            var randomId = new Random().Next(0,99999999);
            var student = new Student(randomId, studentRequest.Name, studentRequest.DateOfBirth);
            _studentRepository.AddStudent(student);
        }

        public StudentResponse? GetStudentById(int id)
        {
            if (id > 0)
            {
                var student = _studentRepository.GetStudentById(id);
                return new StudentResponse
                {
                    Id = student!.GetId(),
                    Name = student.Name,
                    DateOfBirth = student.BirthDate
                };
            }
            else
                throw new ArgumentException("student id cannot be negative");
        }

        public IEnumerable<StudentResponse> GetAllStudents()
        {
            var randomId = GetRandomId();
            var students = _studentRepository.GetAllStudents();
            return students.Select(s => new StudentResponse { Id = randomId, DateOfBirth = s.BirthDate, Name = s.Name });
        }
        private int GetRandomId ()=> new Random().Next(0, 99999999);
    }
}
