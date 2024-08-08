namespace ACME.School.Domain.Entities
{
    public class Course
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal RegistrationFee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        private List<Student> _students = [];

        public IEnumerable<Student> Students => _students.AsEnumerable();
        private Course() { }
        public Course(int id, string name, decimal registrationFee, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            RegistrationFee = registrationFee;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void AddStudent(Student student)
        {
            _students.Add(student);
        } 
    }
}
