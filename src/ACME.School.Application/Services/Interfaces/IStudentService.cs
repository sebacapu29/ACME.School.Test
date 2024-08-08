using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.DTOs.Responses;

namespace ACME.School.Application.Services.Interfaces
{
    public interface IStudentService
    {
        void RegisterStudent(StudentRequest student);
        StudentResponse? GetStudentById(int id);
        IEnumerable<StudentResponse> GetAllStudents();
    }
}
