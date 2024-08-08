using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.DTOs.Responses;

namespace ACME.School.Application.Services.Interfaces
{
    public interface ICourseService
    {
        void RegisterCourse(CourseRequest course);
        IEnumerable<CourseResponse> GetAllCourses();
        IEnumerable<CourseResponse> GetCoursesInRange(DateTime startDate, DateTime endDate);
    }
}
