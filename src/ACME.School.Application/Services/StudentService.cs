using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using ACME.School.Domain.Services;

namespace ACME.School.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public void RegisterStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
    }
}
