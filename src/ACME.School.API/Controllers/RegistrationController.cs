using ACME.School.Application.DTOs.Requests;
using ACME.School.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ACME.School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }
        [HttpPost]
        public IActionResult RegisterStudentInCourse(RegistrationRequest registrationRequest)
        {
            return Ok(_registrationService.RegisterStudentInCourse(registrationRequest));
        }
    }
}
