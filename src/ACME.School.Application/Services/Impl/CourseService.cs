using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.DTOs.Responses;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Application.Validators;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using FluentValidation;
using System;

namespace ACME.School.Application.Services.Impl
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IValidator<CourseRequest> _courseValidator;

        public CourseService(ICourseRepository courseRepository, IValidator<CourseRequest> courseValidator)
        {
            _courseRepository = courseRepository;
            _courseValidator = courseValidator;
        }

        public void RegisterCourse(CourseRequest courseRequest)
        {
            _courseValidator.Validate(courseRequest);
            var randomId = GetRandomId();
            var course = new Course(randomId, courseRequest.Name, courseRequest.RegistrationFee, courseRequest.StartDate, courseRequest.EndDate);
             _courseRepository.AddCourse(course);
        }

        public IEnumerable<CourseResponse> GetCoursesInRange(DateTime startDate, DateTime endDate)
        {
            var courses = _courseRepository.GetAllCourses();
            var courseFiltered =  courses.Where(course => course.StartDate >= startDate && course.EndDate <= endDate);
            if (!courseFiltered!.ToList().Any())
                throw new ArgumentException("course not found");

            return courseFiltered.Select(c => new CourseResponse { Id = c.Id, EndDate = c.EndDate, StartDate = c.StartDate, Name = c.Name, RegistrationFee = c.RegistrationFee });
        }
        private int GetRandomId() => new Random().Next(0, 99999999);

        public IEnumerable<CourseResponse> GetAllCourses()
        {
            var courseFiltered =  _courseRepository.GetAllCourses();
            return courseFiltered.Select(c => new CourseResponse { Id = c.Id, EndDate = c.EndDate, StartDate = c.StartDate, Name = c.Name, RegistrationFee = c.RegistrationFee });
        }
    }
}
