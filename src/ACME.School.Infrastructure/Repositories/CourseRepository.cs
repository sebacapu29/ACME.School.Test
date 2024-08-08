using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;

namespace ACME.School.Infrastructure.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SchoolContext _context;
        public CourseRepository(SchoolContext context)
        {
            _context = context;
        }
        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            _context.Courses.Remove(course);
            _context.SaveChanges();
        }

        public Course? GetCourseById(int id)
        {
            if (id > 0)
                return _context.Courses.Find(id);
            else
                throw new ArgumentException("course Id cannot be negative");
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.AsEnumerable();
        }
    }
}
