using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;

namespace ACME.School.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolContext _context;

        public StudentRepository(SchoolContext context)
        {
            _context = context;
        }

        public void AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
        }

        public Student? GetStudentById(int id)
        {
             return _context.Students.Find(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.AsEnumerable();
        }
    }
}
