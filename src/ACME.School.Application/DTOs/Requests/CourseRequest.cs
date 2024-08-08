namespace ACME.School.Application.DTOs.Requests
{
    public class CourseRequest
    {
        public string? Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
