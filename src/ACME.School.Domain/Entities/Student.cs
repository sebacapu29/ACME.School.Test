namespace ACME.School.Domain.Entities
{
    public class Student
    {
        private int Id { get; set; }
        public string Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        private List<Course> _registeredCourses = [];

        public IEnumerable<Course> RegisteredCourses => _registeredCourses.AsEnumerable();

        public Student(int id, string name, DateTime birthDate)
        {
            Id = id;
            Name = name;
            BirthDate = birthDate;
        }
        public int GetId() => Id;
        public void RegisterForCourse(Course course)
        {
            _registeredCourses.Add(course);
        }
    }
}
