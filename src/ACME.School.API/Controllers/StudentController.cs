using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.Services.Interfaces;
using ACME.School.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ACME.School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public IActionResult RegisterStudent(StudentRequest student)
        {;
            _studentService.RegisterStudent(student);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
             return Ok(_studentService.GetStudentById(id));
        }
        [HttpGet("get-all")]
        public IActionResult GetAllStudents()
        {
             return Ok(_studentService.GetAllStudents());
        }
    }
}
