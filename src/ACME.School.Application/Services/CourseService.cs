using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using ACME.School.Domain.Services;

namespace ACME.School.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public void RegisterCourse(Course course)
        {
            _courseRepository.AddCourse(course);
        }

        public IEnumerable<Course> GetCoursesInRange(DateTime startDate, DateTime endDate)
        {
            var courses = _courseRepository.GetAllCourses();
            return courses.Where(course => course.StartDate >= startDate && course.EndDate <= endDate);
        }
    }
}
