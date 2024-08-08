using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Domain.Repositories;

namespace ACME.School.Application.Services.Impl
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IPaymentGateway _paymentGateway;

        public RegistrationService(IStudentRepository studentRepository, ICourseRepository courseRepository, IPaymentGateway paymentGateway)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _paymentGateway = paymentGateway;
        }

        public bool RegisterStudentInCourse(RegistrationRequest registrationRequest)
        {
            var student = _studentRepository.GetStudentById(registrationRequest.StudentId);
            if (student == null)
                throw new ArgumentException("Student not found");

            var course = _courseRepository.GetCourseById(registrationRequest.CourseId);
            if (course == null)
                throw new ArgumentException("Course not found");

            if (course.RegistrationFee > 0)
            {
                var paymentSuccessful = _paymentGateway.ProcessPayment(course.RegistrationFee);
                if (!paymentSuccessful) return false;
            }

            student.RegisterForCourse(course);
            course.AddStudent(student);

            _studentRepository.UpdateStudent(student);
            _courseRepository.UpdateCourse(course);

            return true;
        }
    }
}
