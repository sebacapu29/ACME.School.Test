using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Domain.Entities;
using ACME.School.Domain.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ACME.School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpPost]
        public IActionResult AddCourse(CourseRequest course)
        {
            _courseService.RegisterCourse(course);
            return Ok();
        }
        /// <summary>
        /// Get Courses In Range
        /// </summary>
        /// <param name="startDate">Format: dd-mm-yyyy</param>
        /// <param name="endDate">Format: dd-mm-yyyy</param>
        /// <returns></returns>
        [HttpGet("{startDate}/{endDate}")]        
        public IActionResult GetCourseInRange(DateTime startDate, DateTime endDate)
        {
             return Ok(_courseService.GetCoursesInRange(startDate,endDate));
        }
        [HttpGet("get-all")]
        public IActionResult GetAllCourses()
        {
            return Ok(_courseService.GetAllCourses());
        }
    }
}
