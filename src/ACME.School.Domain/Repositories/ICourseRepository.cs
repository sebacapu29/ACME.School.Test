using ACME.School.Domain.Entities;

namespace ACME.School.Domain.Repositories
{
    public interface ICourseRepository
    {
        void AddCourse(Course course);
        Course GetCourseById(int id);
        IEnumerable<Course> GetAllCourses();
        void UpdateCourse(Course course);
    }
}
