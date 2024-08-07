using ACME.School.Domain.Entities;

namespace ACME.School.Domain.Services
{
    public interface IStudentService
    {
        void RegisterStudent(Student student);
        Student GetStudentById(int id);
        IEnumerable<Student> GetAllStudents();
    }
}
