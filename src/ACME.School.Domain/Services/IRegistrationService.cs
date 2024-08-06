namespace ACME.School.Domain.Services
{
    public interface IRegistrationService
    {
        bool RegisterStudentInCourse(int studentId, int courseId);
    }
}
