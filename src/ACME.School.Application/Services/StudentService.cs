using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using ACME.School.Domain.Services;

namespace ACME.School.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IPaymentGateway _paymentGateway;

        public StudentService(IStudentRepository studentRepository, ICourseRepository courseRepository, IPaymentGateway paymentGateway)
        {
            _studentRepository = studentRepository;
            _courseRepository = courseRepository;
            _paymentGateway = paymentGateway;
        }
        public void RegisterStudent(Student student)
        {
            _studentRepository.AddStudent(student);
        }

        public Student? GetStudentById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            return _studentRepository.GetAllStudents();
        }
    }
}
