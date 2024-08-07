using ACME.School.Domain.Entities;

namespace ACME.School.Domain.Repositories
{
    public interface IStudentRepository
    {
        void AddStudent(Student student);
        Student? GetStudentById(int id);
        IEnumerable<Student> GetAllStudents();
        void UpdateStudent(Student student);        
    }
}
