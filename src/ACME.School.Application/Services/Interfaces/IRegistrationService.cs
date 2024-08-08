using ACME.School.Application.DTOs.Requests;

namespace ACME.School.Application.Services.Interfaces
{
    public interface IRegistrationService
    {
        bool RegisterStudentInCourse(RegistrationRequest registration);
    }
}
