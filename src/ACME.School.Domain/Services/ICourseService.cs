using ACME.School.Domain.Entities;

namespace ACME.School.Domain.Services
{
    public interface ICourseService
    {
        void RegisterCourse(Course course);
        IEnumerable<Course> GetCoursesInRange(DateTime startDate, DateTime endDate);
    }
}
