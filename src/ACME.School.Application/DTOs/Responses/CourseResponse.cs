namespace ACME.School.Application.DTOs.Responses
{
    public class CourseResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal RegistrationFee { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
